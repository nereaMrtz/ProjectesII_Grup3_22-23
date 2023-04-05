using System;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1.SimonDice
{
    public class ClickableButton_SimonDice : MonoBehaviour
    {
        private const int PLAYER_LAYER = 6;

        private const String PRESS_BUTTON = "Press Button";
        private const String RELEASE_BUTTON = "Release Button";
        
        [SerializeField] private Controller_SimonDice _controllerSimonDice;

        [SerializeField] private Animator _animator;
        
        [SerializeField] private int _buttonIndex;
        
        private AudioSource _audioSourcePressButton;
        private AudioSource _audioSourceReleaseButton;
        
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
            _controllerSimonDice.CheckCombination(_buttonIndex);
        }
    }
}
