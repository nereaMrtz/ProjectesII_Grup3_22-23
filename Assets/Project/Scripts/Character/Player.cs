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

        [SerializeField] private bool _moving;
        

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
            if (GameManager.Instance.IsInZoomInState() || GameManager.Instance.IsFading())
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
                AudioManager.Instance.UnPause(STEPS_SOUND_CLIP_NAME);
            }
            else
            {
                AudioManager.Instance.Pause(STEPS_SOUND_CLIP_NAME);
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

            _moving = _rigidbody2D.velocity.magnitude > 0.01f;
            
            animator.SetInteger("Horizontal", (int)_movementDirection.x);
            animator.SetInteger("Vertical", (int)_movementDirection.y);
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