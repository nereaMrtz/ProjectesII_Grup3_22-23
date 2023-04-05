using System;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1.PapelesInvertidos
{
    public class Button_PapelesInvertidos : MonoBehaviour
    {
        private const String STEPS_SOUND_CLIP_NAME = "Steps Sound";
        
        [SerializeField] private Rigidbody2D _rigidbody2D;

        private readonly float _currentSpeed = 200;

        private Vector2 _movementDirection;
        
        void Update()
        {
            Controls();
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
                AudioManager.Instance.Pause(STEPS_SOUND_CLIP_NAME);
                return;
            }

            MovementController();
        }

        private void MovementController()
        {
            _movementDirection = Vector2.zero;

            if (Input.GetKey(KeyCode.A))
            {
                _movementDirection.x += -1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                _movementDirection.x += 1;
            }
            if (Input.GetKey(KeyCode.W))
            {
                _movementDirection.y += 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                _movementDirection.y += -1;
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
                _rigidbody2D.velocity = Vector2.zero;
            }
            else 
            {
                _rigidbody2D.AddForce(_movementDirection * _currentSpeed, ForceMode2D.Force);
            }   
        }
    }
}
