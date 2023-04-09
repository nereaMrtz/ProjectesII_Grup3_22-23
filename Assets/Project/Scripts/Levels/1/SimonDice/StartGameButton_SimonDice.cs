using System;
using System.Collections;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1.SimonDice
{
    public class StartGameButton_SimonDice : MonoBehaviour
    {
        private const int PLAYER_LAYER = 6;

        private const String PRESS_BUTTON = "Press Button";
        private const String RELEASE_BUTTON = "Release Button";
        
        [SerializeField] private Controller_SimonDice _controllerSimonDice;
       
        [SerializeField] private SpriteRenderer _spriteRenderer;

        [SerializeField] private CapsuleCollider2D _capsuleCollider;

        [SerializeField] private Animator _animator;
        
        private AudioSource _audioSourcePressButton;
        private AudioSource _audioSourceReleaseButton;
        
        private void Start()
        {
            _audioSourcePressButton = gameObject.AddComponent<AudioSource>();
            _audioSourceReleaseButton = gameObject.AddComponent<AudioSource>();
            AudioManager.Instance.SetAudioSourceComponent(_audioSourcePressButton, PRESS_BUTTON);
            AudioManager.Instance.SetAudioSourceComponent(_audioSourceReleaseButton, RELEASE_BUTTON);
        }

        private void OnEnable()
        {
            StartCoroutine(FadeInButton());
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            _audioSourcePressButton.Play();
            _animator.SetTrigger("Press");
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            _audioSourceReleaseButton.Play();
            _animator.SetTrigger("Press");
            _capsuleCollider.enabled = false;
            _controllerSimonDice.StartGame();
            StartCoroutine(FadeOutButton());
        }

        private IEnumerator FadeOutButton()
        {
            Color color = _spriteRenderer.color;
            
            float auxAlpha = color.a;
            
            while (auxAlpha > 0f)
            {
                auxAlpha -= Time.deltaTime / 1.1f;
                _spriteRenderer.color = new Color(color.r, color.g, color.b, auxAlpha);
                yield return null;
            }
            gameObject.SetActive(false);
        }
        
        private IEnumerator FadeInButton()
        {
            Color color = _spriteRenderer.color;
            
            float auxAlpha = color.a;
            
            while (auxAlpha < 1f)
            {
                auxAlpha += Time.deltaTime / 1.1f;
                _spriteRenderer.color = new Color(color.r, color.g, color.b, auxAlpha);
                yield return null;
            }

            _capsuleCollider.enabled = true;
        }
    }
}
