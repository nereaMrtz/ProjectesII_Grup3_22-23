using System;
using Project.Scripts.Levels._1._1_1;
using Project.Scripts.Managers;
using Project.Scripts.UI;
using UnityEngine;

namespace Project.Scripts.Levels._1.NoLoToques
{
    public class Button_NoLoToques : MonoBehaviour
    {
        protected const int PLAYER_LAYER = 6;

        private const String PRESS_BUTTON = "Press Button";
        private const String RELEASE_BUTTON = "Release Button";

        [SerializeField] protected Animator _animator;

        [SerializeField] protected Door _door;

        [SerializeField] private ResetLevelButton _resetButton;

        private AudioSource _audioSourcePressButton;
        private AudioSource _audioSourceReleaseButton;

        protected bool _pressed;

        private void Start()
        {
            _audioSourcePressButton = gameObject.AddComponent<AudioSource>();
            _audioSourceReleaseButton = gameObject.AddComponent<AudioSource>();
            AudioManager.Instance.SetAudioSourceComponent(_audioSourcePressButton, PRESS_BUTTON);
            AudioManager.Instance.SetAudioSourceComponent(_audioSourceReleaseButton, RELEASE_BUTTON);
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            
            if (!_pressed)
            {
                StartCoroutine(_resetButton.FlashButton());    
            }
            _audioSourcePressButton.Play();
            PressButton();
            _door.CloseDoor();
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            
            _audioSourceReleaseButton.Play();
            PressButton();
        }

        protected void PressButton()
        {
            _pressed = true;
            _animator.SetTrigger("Press");
        }
    }
}
