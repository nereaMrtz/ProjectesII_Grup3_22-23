using System;
using System.Collections;
using Project.Scripts.Character;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1.NoToques
{
    public class Button_NoToques : MonoBehaviour
    {
        protected const int PLAYER_LAYER = 6;
        
        private const String PUSH_BUTTON = "ArrastrarBoton(NoToques)";
        private const String PRESS_BUTTON = "Press Button";
        private const String RELEASE_BUTTON = "Release Button";
        
        [SerializeField] private Player _player;

        [SerializeField] private float _timeToDisappear;

        [SerializeField] private SpriteRenderer _spriteRenderer;

        [SerializeField] private GameObject _trigger;

        private AudioSource _audioSourcePressButton;
        private AudioSource _audioSourceReleaseButton;
        private AudioSource _audioSourcePushButton;

        private Vector3 _initialPosition;
        
        private Color _color;

        private float _currentTime;

        private bool _moved;
        private bool _collidedWithPlayer;

        private void Start()
        {
            _initialPosition = transform.position;
            _currentTime = _timeToDisappear;
            _color = _spriteRenderer.color;
            _audioSourcePressButton = gameObject.AddComponent<AudioSource>();
            _audioSourceReleaseButton = gameObject.AddComponent<AudioSource>();
            _audioSourcePushButton = gameObject.AddComponent<AudioSource>();
            AudioManager.Instance.SetAudioSourceComponent(_audioSourcePressButton, PRESS_BUTTON);
            AudioManager.Instance.SetAudioSourceComponent(_audioSourceReleaseButton, RELEASE_BUTTON);
            AudioManager.Instance.SetAudioSourceComponent(_audioSourcePushButton, PUSH_BUTTON);
        }

        private void Update()
        {
            if (_collidedWithPlayer && _trigger == null)
            {
                StartCoroutine(GoBack());
                _collidedWithPlayer = false;
                return;
            }
            
            _currentTime -= Time.deltaTime;

            if (_player.GetMovement().magnitude != 0)
            {
                _currentTime = _timeToDisappear;
            }

            if (_currentTime<= 0)
            {
                StartCoroutine(Disappear());
            }
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }

            _audioSourcePressButton.Play();
            _collidedWithPlayer = true;
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }

            _audioSourceReleaseButton.Play();
        }

        private IEnumerator Disappear()
        {
            float auxAlpha = _color.a;
            
            while (auxAlpha > 0)
            {
                auxAlpha -= Time.deltaTime * 2;
                _spriteRenderer.color = new Color(_color.r, _color.g, _color.b, auxAlpha);
                yield return null;
            }
            
            Destroy(_trigger);
            Destroy(gameObject);
        }

        private IEnumerator GoBack()
        {
            _audioSourcePushButton.Play();
            while (Vector3.Distance(transform.position, _initialPosition) > 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, _initialPosition, Time.deltaTime * 2);
                yield return null;
            }
            
            Destroy(this);
        }
    }
}
