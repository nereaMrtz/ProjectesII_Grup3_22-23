using System;
using UnityEngine;
using Project.Scripts.Managers;
using Vector2 = UnityEngine.Vector2;

namespace Project.Scripts.Character
{
    public class Player : MonoBehaviour
    {
        private const String STEPS_SOUND_CLIP_NAME = "Steps Sound";
        
        [SerializeField] private GameObject _pauseMenuPanel;

        [SerializeField] private Rigidbody2D _rigidbody2D;

        [SerializeField] private float _currentSpeed = 75;

        private Vector2 movementDirection;

        private float _movementX;
        private float _movementY;

        void Update()
        {
            if (_pauseMenuPanel.activeSelf)
            {
                return;
            }
            
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
            _movementX = 0;
            _movementY = 0;

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

        private void Movement() {
            movementDirection = new Vector3(_movementX, _movementY).normalized;
            if (movementDirection != new Vector2(0,0))
            {
                AudioManager.Instance.UnPause(STEPS_SOUND_CLIP_NAME);
            }
            else
            {
                AudioManager.Instance.Pause(STEPS_SOUND_CLIP_NAME);
            }
            _rigidbody2D.AddForce(movementDirection * _currentSpeed, ForceMode2D.Force);
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
    }
}