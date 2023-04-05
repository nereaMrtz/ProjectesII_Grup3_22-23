using System;
using Project.Scripts.Interactable.Static;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1.PapelesInvertidos
{
    public class Player_PapelesInvertidos : MonoBehaviour
    {
        private const int PLAYER_LAYER = 6;

        private const String PRESS_BUTTON = "PulsarBoton";
        private const String RELEASE_BUTTON = "SoltarBoton";
        
        [SerializeField] protected Animator _buttonAnimator;
        
        [SerializeField] protected UnlockableObject _door;

        private AudioSource _audioSourcePressButton;
        private AudioSource _audioSourceReleaseButton;

        private bool _pressed;

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

        private void ButtonAction()
        {
            _pressed = !_pressed;
            ButtonAnimation();
        }

        private void ButtonAnimation()
        {
            _buttonAnimator.SetTrigger("Press");
        }
    }
}
