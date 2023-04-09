using System;
using Project.Scripts.Levels._1.Manten;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1.MantenPlanta
{
    public class Button_MantenPlanta : MonoBehaviour
    {
        private const String PRESS_BUTTON = "Press Button";
        private const String RELEASE_BUTTON = "Release Button";
        
        [SerializeField] private Animator _animator;

        [SerializeField] private Door_Manten _door;

        [SerializeField] private Collider2D _dragCollider;

        private AudioSource _audioSourcePressButton;
        private AudioSource _audioSourceReleaseButton;

        private void Start()
        {
            _audioSourcePressButton = gameObject.AddComponent<AudioSource>();
            _audioSourceReleaseButton = gameObject.AddComponent<AudioSource>();
            AudioManager.Instance.SetAudioSourceComponent(_audioSourcePressButton, PRESS_BUTTON);
            AudioManager.Instance.SetAudioSourceComponent(_audioSourceReleaseButton, RELEASE_BUTTON);
            Physics2D.IgnoreCollision(_dragCollider,GetComponent<Collider2D>());
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {

            _door.Open();
            _audioSourcePressButton.Play();
            _animator.SetTrigger("Press");
            
            _door.AnimatorStep(true);
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            _audioSourceReleaseButton.Play();
            _animator.SetTrigger("Press");
            
            _door.AnimatorStep(false);
            _door.ChangePolygonCollider(0);
        }
    }
}
