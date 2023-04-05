using System;
using System.Collections;
using Project.Scripts.Character;
using Project.Scripts.Managers;
using Unity.VisualScripting;
using UnityEngine;

namespace Project.Scripts.Levels._1.NoToques
{
    public class Button_NoToques : MonoBehaviour
    {
        protected const int PLAYER_LAYER = 6;
        
        private const String ARRASTRAR_BOTON = "ArrastrarBoton(NoToques)";
        private const String PULSAR_BOTON = "Press Button";
        private const String SOLTAR_BOTON = "Release Button";
        
        [SerializeField] private Player _player;

        [SerializeField] private float _timeToDisappear;

        [SerializeField] private SpriteRenderer _spriteRenderer;

        [SerializeField] private GameObject _trigger;

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

            AudioManager.Instance.Play(PULSAR_BOTON, gameObject);
            _collidedWithPlayer = true;
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }

            AudioManager.Instance.Play(SOLTAR_BOTON, gameObject);
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
            AudioManager.Instance.Play(ARRASTRAR_BOTON, gameObject);
            while (Vector3.Distance(transform.position, _initialPosition) > 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, _initialPosition, Time.deltaTime * 2);
                yield return null;
            }
            
            Destroy(this);
        }
    }
}
