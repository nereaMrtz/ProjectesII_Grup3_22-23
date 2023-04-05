using System;
using Project.Scripts.Levels._1.Manten;
using Project.Scripts.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.Levels._1.ComoUnHuevo
{
    public class Button_ComoUnHuevo : MonoBehaviour
    {
        private const int PLAYER_LAYER = 6;

        private const String PRESS_BUTTON = "Press Button";
        private const String RELEASE_BUTTON = "Release Button";
        
        [SerializeField] private Door_Manten _door;

        [SerializeField] private float _timeToHold;

        [SerializeField] private Animator _animator;

        [SerializeField] private float _currentTimeToHold;

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
            _animator.SetTrigger("Press");
            _currentTimeToHold = _timeToHold;
            _door.AnimatorStep(true);
            
        }

        private void OnTriggerStay2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }

            _currentTimeToHold -= Time.deltaTime;

            if (_currentTimeToHold <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            _currentTimeToHold = _timeToHold;
            _door.AnimatorStep(false);
            _door.ChangePolygonCollider(0);
        }
    }
}
