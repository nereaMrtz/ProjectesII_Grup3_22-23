using System;
using UnityEngine;
using Project.Scripts.Managers;
using Project.Scripts.NoMonoBehaviourClass;
using UnityEngine.SceneManagement;

namespace Project.Scripts.Character
{
    public class Player : MonoBehaviour
    {
        private const String STEPS_SOUND_CLIP_NAME = "Steps Sound";
        
        [SerializeField] private GameObject _pauseMenuPanel;

        [SerializeField] private Rigidbody2D _rigidbody2D;

        [SerializeField] private float _currentSpeed = 75;

        [SerializeField] private bool _inverted;

        public Animator animator;

        private Vector2 _movementDirection;

        private float _movementX;
        private float _movementY;

        private float _lastX;
        private float _lastY;

        private bool _isMoving;
        

        void Update()
        {
            _movementX = 0;
            _movementY = 0;
            
            if (_pauseMenuPanel.activeSelf)
            {
                return;
            }

            Controls();

            UpdateAnimationController();
        }

        private void FixedUpdate()
        {
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
            _isMoving = false;

            if (Input.GetKey(KeyCode.A))
            {
                _movementX = _inverted ? 1 : -1;
                _lastX = _movementX;
                _lastY = 0;
                _isMoving = true;
            }
            if (Input.GetKey(KeyCode.D))
            {
                _movementX = _inverted ? -1 : 1;
                _lastX = _movementX;
                _lastY = 0;
                _isMoving = true;
            }
            if (Input.GetKey(KeyCode.W))
            {
                _movementY = _inverted ? -1 : 1;
                _lastY = _movementY;
                _lastX = 0;
                _isMoving = true;
            }
            if (Input.GetKey(KeyCode.S))
            {
                _movementY = _inverted ? 1 : -1;
                _lastY = _movementY;
                _lastX = 0;
                _isMoving = true;
            }            
        }

        private void Movement() {
            
            _movementDirection = new Vector3(_movementX, _movementY).normalized;

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

            animator.SetFloat("Horizontal", _movementX);
            animator.SetFloat("Vertical", _movementY);
            animator.SetFloat("lastX", _lastX);
            animator.SetFloat("lastY", _lastY);
            animator.SetBool("isMoving", _isMoving);            
        }

        public void Pause()
        {
            _pauseMenuPanel.SetActive(true);
            GameManager.Instance.SetPause(true);
        }

        public float GetMovementX()
        {
            return _movementX;
        }

        public float GetMovementY()
        {
            return _movementY;
        }

        public Rigidbody2D GetRigidbody2D() {
        
            return _rigidbody2D;
        }
    }
}