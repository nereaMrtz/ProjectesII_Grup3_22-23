using System;
using Project.Scripts.Levels._1._1_1;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1.BrisaPorLaEspalda
{
    public class Door_BrisaPorLaEspalda : Door
    {
        private const int PLAYER_LAYER = 6;
        
        [SerializeField] private Animator _playerAnimator;

        private bool _startOpening;

        private void Start()
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
            AudioManager.Instance.SetAudioSourceComponent(_audioSource, SIMPLE_DOOR_SOUND);
        }

        private void OnTriggerStay2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }

            if (_playerAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "idle_front")
            {
                AnimatorStep(false);
                if (_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Closed Door" && _startOpening)
                {
                    _startOpening = false;
                }
                return;
            }
                
            if (!_startOpening)
            {
                _audioSource.Play();
                _startOpening = true;
            }
            
            AnimatorStep(true);
        }
        
        private void AnimatorStep(bool turnBack) {
                        
            _animator.SetBool("Open", turnBack);          
        }
    }
}
