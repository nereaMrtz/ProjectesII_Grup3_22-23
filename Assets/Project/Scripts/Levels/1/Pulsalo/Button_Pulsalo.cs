using System;
using Project.Scripts.Interactable.Static;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1.Pulsalo
{
    public class Button_Pulsalo : MonoBehaviour
    {

        private const String PRESS_BUTTON = "PulsarBoton";
        private const String RELEASE_BUTTON = "SoltarBoton";
        
        [SerializeField] protected Animator _animator;
        
        [SerializeField] protected UnlockableObject _door;

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

        private void OnMouseDown()
        {
            if (!_door.IsUnlocked())
            {
                _door.Unlock();
            }
            _audioSourcePressButton.Play();
            ButtonAction();
        }

        private void OnMouseUp()
        {
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
    }
}
