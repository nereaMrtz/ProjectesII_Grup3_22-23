using System;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Character
{
    public class Player : MonoBehaviour
    {
        private const String STEPS_SOUND_CLIP_NAME = "Steps Sound";
        private const String STEPS_GRASS_SOUND_CLIP_NAME = "Steps Grass Sound";
        private const String GHOST_SOUND_CLIP_NAME = "Ghost Sound";

        [SerializeField] private Rigidbody2D _rigidbody2D;

        [SerializeField] private Animator animator;

        [SerializeField] private bool _moveWithKeyboard;
        [SerializeField] private bool _inverted;

        private AudioSource _audioSourceSoundSteps;
        private AudioSource _audioSourceSoundGrassSteps;
        private AudioSource _audioSourceSoundGhost;
        
        private readonly float _currentSpeed = 200;
        
        private bool _moving;

        private Vector2 _movementDirection;

        private void Start()
        {
            _audioSourceSoundSteps = gameObject.AddComponent<AudioSource>();
            _audioSourceSoundGrassSteps = gameObject.AddComponent<AudioSource>();
            _audioSourceSoundGhost = gameObject.AddComponent<AudioSource>();
            AudioManager.Instance.SetAudioSourceComponent(_audioSourceSoundSteps, STEPS_SOUND_CLIP_NAME);
            AudioManager.Instance.SetAudioSourceComponent(_audioSourceSoundGrassSteps, STEPS_GRASS_SOUND_CLIP_NAME);
            AudioManager.Instance.SetAudioSourceComponent(_audioSourceSoundGhost, GHOST_SOUND_CLIP_NAME);

            _audioSourceSoundGrassSteps.Pause();
            _audioSourceSoundGhost.Pause();
        }

        void Update()
        {
            
            if (_moveWithKeyboard)
            {
                Controls();

            }
            UpdateAnimationController();

            Cheats();

        }

        private void Cheats()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                GameManager.Instance.UnlockAllLevels();
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                GameManager.Instance.GoNextLevel();
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                GameManager.Instance.GoLastLevel();
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                GameManager.Instance.AlterCoins(1);
            }
        }

        private void FixedUpdate()
        {
            Movement();
        }

        private void Controls()
        {
            if (GameManager.Instance.IsPause() || GameManager.Instance.IsFading())
            {
                _movementDirection = Vector2.zero;
                
                PauseStepsSound();
                
                return;
            }

            MovementController();
        }

        private void MovementController()
        {
            if (!_moveWithKeyboard)
            {
                return;
            }

            _movementDirection = Vector2.zero;

            if (Input.GetKey(KeyCode.A))
            {
                _movementDirection.x += _inverted ? 1 : -1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                _movementDirection.x += _inverted ? -1 : 1;
            }
            if (Input.GetKey(KeyCode.W))
            {
                _movementDirection.y += _inverted ? -1 : 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                _movementDirection.y += _inverted ? 1 : -1;
            }
        }

        private void Movement() {
            
            _movementDirection = _movementDirection.normalized;
                        
            if (_movementDirection.magnitude != 0)
            {
                _rigidbody2D.AddForce(_movementDirection * _currentSpeed, ForceMode2D.Force);

                if (_rigidbody2D.velocity.magnitude == 0)
                {
                    PauseStepsSound();
                    return;
                }
                
                if (!GameManager.Instance.IsOutside() && !GameManager.Instance.IsGhost())
                {
                    _audioSourceSoundSteps.UnPause();
                    _audioSourceSoundGrassSteps.Pause();
                }
                else if (GameManager.Instance.IsOutside())
                {
                    _audioSourceSoundGrassSteps.UnPause();
                    _audioSourceSoundSteps.Pause();
                }
                else if (GameManager.Instance.IsGhost())
                {
                    _audioSourceSoundGhost.UnPause();
                }
            }
            else
            {
                _moving = false;
                _rigidbody2D.velocity = Vector2.zero;
                
                PauseStepsSound();
            }  
        }

        private void UpdateAnimationController(){

            _moving = _rigidbody2D.velocity.magnitude > 0;
            
            animator.SetInteger("Horizontal", (int)_movementDirection.x);
            animator.SetInteger("Vertical", (int)_movementDirection.y);
            animator.SetBool("isMoving", _moving);            
        }

        public Vector2 GetMovement()
        {
            return _movementDirection;
        }

        public void SetMoving(bool moving)
        {
            _moving = moving;
        }

        public void SetMovementDirection(Vector2 movementDirection)
        {
            _movementDirection = movementDirection;
        }

        private void PauseStepsSound()
        {
            if (!GameManager.Instance.IsOutside() && !GameManager.Instance.IsGhost())
            {
                _audioSourceSoundSteps.Pause();    
            }
            else if (GameManager.Instance.IsOutside())
            {
                _audioSourceSoundGrassSteps.Pause();
            }
            else if (GameManager.Instance.IsGhost())
            {
                _audioSourceSoundGhost.Pause();
            }
        }
    }
}