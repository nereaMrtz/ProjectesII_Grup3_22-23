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

        //public Rigidbody2D rgb;
        public Animator animator;

        private Vector2 movementDirection;

        private Vector2 _movementDirection;

        private float _movementX;
        private float _movementY;

        void Update()
        {
            _movementX = 0;
            _movementY = 0;
            
            if (_pauseMenuPanel.activeSelf)
            {
                return;
            }

            animator.SetFloat("Horizontal", _movementX);
            animator.SetFloat("Vertical", _movementY);
            animator.SetFloat("Speed", movementDirection.sqrMagnitude);

            Controls();
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
            if (SceneManager.GetActiveScene().buildIndex == 5)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    _movementX += 1;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    _movementX += -1;
                }
                if (Input.GetKey(KeyCode.W))
                {
                    _movementY += -1;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    _movementY += 1;
                }
            }
            else {
                if (Input.GetKey(KeyCode.A))
                {
                    _movementX += -1;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    _movementX += 1;
                }
                if (Input.GetKey(KeyCode.W))
                {
                    _movementY += 1;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    _movementY += -1;
                }
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