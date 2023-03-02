using System;
using UnityEngine;
using Project.Scripts.Managers;

namespace Project.Scripts.Character
{
    public class Player : MonoBehaviour
    {
        private const String STEPS_SOUND_CLIP_NAME = "Steps Sound";
        
        [SerializeField] private GameObject _pauseMenuPanel;

        [SerializeField] private Rigidbody2D _rigidbody2D;

        [SerializeField] private float _currentSpeed = 75;

        [SerializeField] private bool _moveWithKeyboard;
        
        [SerializeField] private bool _move;
        
        [SerializeField] private bool _inverted;

        public Animator animator;

        private Vector2 _movementDirection;
        private Vector2 _lastMovement;

        [SerializeField] private bool _moving;
        [SerializeField] private bool _movingWithOutKeyBoard;
        

        void Update()
        {
            if (_pauseMenuPanel.activeSelf)
            {
                return;
            }

            if (_moveWithKeyboard)
            {
                Controls();    
            }

            UpdateAnimationController();
        }

        private void FixedUpdate()
        {
            if (!_move)
            {
                return;
            }
            Movement();
        }

        private void Controls()
        {
            if (GameManager.Instance.IsInZoomInState())
            {
                AudioManager.Instance.Pause(STEPS_SOUND_CLIP_NAME);
                return;
            }

            MovementController();
        }

        private void MovementController()
        {
            if (_moveWithKeyboard)
            {
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
                {
                    _moving = true;
                }

                if (_moving)
                {
                    if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
                    {
                        _moving = false;
                        _movementDirection = Vector2.zero;
                    }   
                }
                
                if (Input.GetKey(KeyCode.A))
                {
                    _movementDirection.x = _inverted ? 1 : -1;
                    _lastMovement = _movementDirection;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    _movementDirection.x = _inverted ? -1 : 1;
                    _lastMovement = _movementDirection;
                }
                if (Input.GetKey(KeyCode.W))
                {
                    _movementDirection.y = _inverted ? -1 : 1;
                    _lastMovement = _movementDirection;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    _movementDirection.y = _inverted ? 1 : -1;
                    _lastMovement = _movementDirection;
                }
            }
        }

        private void Movement() {
            
            _movementDirection = _movementDirection.normalized;
            
            if (_movementDirection != new Vector2(0,0))
            {
                AudioManager.Instance.UnPause(STEPS_SOUND_CLIP_NAME);
            }
            else
            {
                AudioManager.Instance.Pause(STEPS_SOUND_CLIP_NAME);
            }
            
            _rigidbody2D.AddForce(_movementDirection * _currentSpeed, ForceMode2D.Force);
        }

        private void UpdateAnimationController(){

            animator.SetFloat("Horizontal", _movementDirection.x);
            animator.SetFloat("Vertical", _movementDirection.y);
            animator.SetFloat("lastX", _lastMovement.x);
            animator.SetFloat("lastY", _lastMovement.y);
            animator.SetBool("isMoving", _moving);            
        }

        public void Pause()
        {
            _pauseMenuPanel.SetActive(true);
            GameManager.Instance.SetPause(true);
        }

        public Vector2 GetMovement()
        {
            return _movementDirection;
        }

        public void SetMovement(Vector2 movement)
        {
            _movementDirection = movement;
            
            if (_movementDirection.x != 0)
            {
                _lastMovement.x = _movementDirection.x;
                _lastMovement.y = 0;
            }
            if(_movementDirection.y != 0)
            {
                _lastMovement.y = _movementDirection.y;
                _lastMovement.x = 0;
            }
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