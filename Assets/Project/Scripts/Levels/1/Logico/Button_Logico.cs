using System;
using Project.Scripts.Interactable.Static;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1.Logico
{
    public class Button_Logico : MonoBehaviour
    {
        protected const int PLAYER_LAYER = 6;

        protected const String PRESS_BUTTON = "Press Button";
        protected const String RELEASE_BUTTON = "Release Button";
        
        [SerializeField] protected Animator _animator;
        
        [SerializeField] protected UnlockableObject _door;

        protected AudioSource _audioSourcePressButton;
        protected AudioSource _audioSourceReleaseButton;

        protected bool _pressed;

        protected void Start()
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
            _audioSourcePressButton.Play();
            ButtonAction();
            if (_door.IsUnlocked())
            {
                return;
            }
            _door.Unlock();
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            _audioSourceReleaseButton.Play();
            ButtonAction();
        }

        protected void ButtonAction()
        {
            _pressed = !_pressed;
            ButtonAnimation();
        }

        private void ButtonAnimation()
        {
            _animator.SetTrigger("Press");
        }

        public bool IsPressed()
        {
            return _pressed;
        }
    }
}
