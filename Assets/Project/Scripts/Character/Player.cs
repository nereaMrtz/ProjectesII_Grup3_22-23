using System;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Character
{
    public class Player : MonoBehaviour
    {
        private const String STEPS_SOUND_CLIP_NAME = "Steps Sound";

        [SerializeField] private Rigidbody2D _rigidbody2D;

        [SerializeField] private Animator animator;

        [SerializeField] private bool _moveWithKeyboard;
        [SerializeField] private bool _inverted;

        private AudioSource _audioSource;
        
        private readonly float _currentSpeed = 200;
        
        private bool _moving;

        private Vector2 _movementDirection;

        private void Start()
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
            AudioManager.Instance.SetAudioSourceComponent(_audioSource, STEPS_SOUND_CLIP_NAME);
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
                _audioSource.Pause();
                return;
            }

            MovementController();
        }

        private void MovementController()
        {
            if (_moveWithKeyboard)
            {                
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
        }

        private void Movement() {
            
            _movementDirection = _movementDirection.normalized;
                        
            if (_movementDirection != new Vector2(0,0))
            {
                _audioSource.UnPause();
            }
            else
            {
                _audioSource.Pause();
            }

            if (_movementDirection.magnitude == 0)
            {
                _moving = false;
                _rigidbody2D.velocity = Vector2.zero;
            }
            else 
            {
                _rigidbody2D.AddForce(_movementDirection * _currentSpeed, ForceMode2D.Force);
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
    }
}