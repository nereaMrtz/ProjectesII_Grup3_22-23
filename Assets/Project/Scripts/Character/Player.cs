using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Scripts.ProjectPhysics2D;
using Project.Scripts.Sound;
using Unity.VisualScripting;

namespace Project.Scripts.Character
{
    public class Player : MonoBehaviour
    {
        private const String STEPS_SOUND_CLIP_NAME = "Steps Sound";

        [SerializeField] private AudioManager _audioManager;
        
        [SerializeField] private Rigidbody2D _rigidbody2D;
        
        [SerializeField] private ProjectPhysics2D.ProjectPhysics2D _physics2D;

        public float _currentSpeed = 4;

        private bool _canMoveLeft = true;
        private bool _canMoveRight = true;
        private bool _canMoveUp = true;
        private bool _canMoveDown = true;

        void Start()
        {
            _audioManager = FindObjectOfType<AudioManager>();
        }

        void Update()
        {
            Controls();

            if (Input.GetKey(KeyCode.Space))
                _rigidbody2D.AddForce(Vector2.right * 10f, ForceMode2D.Impulse);
        }

        private void FixedUpdate()
        {
            Movement();
        }
        
        private void Movement()
        {
            float movementX = 0;
            float movementY = 0;
            
            if (Input.GetKey(KeyCode.A) && _canMoveLeft)
            {
                movementX = -1;
            }
            if (Input.GetKey(KeyCode.D) && _canMoveRight)
            {
                movementX = 1;
            }
            if (Input.GetKey(KeyCode.W) && _canMoveUp)
            {
                movementY = 1;
            }
            if (Input.GetKey(KeyCode.S) && _canMoveDown)
            {
                movementY = -1;
            }

            Vector2 movementDirection = new Vector3(movementX, movementY).normalized;

            if (movementDirection.x != 0 || movementDirection.y != 0)
            {
                _audioManager.UnPause(STEPS_SOUND_CLIP_NAME);
            }
            else
            {
                _audioManager.Pause(STEPS_SOUND_CLIP_NAME);
            }

            _rigidbody2D.AddForce(movementDirection * _currentSpeed, ForceMode2D.Force);
        }

        private void Controls()
        {
            
        }

        private void OnCollisionStay2D(Collision2D collision2D)
        {
            if (Vector2.Angle(collision2D.contacts[0].normal, Vector2.right) <= 45f)
            {
                _canMoveLeft = false;
            }
            if (Vector2.Angle(collision2D.contacts[0].normal, Vector2.left) <= 45f)
            {
                _canMoveRight = false;
            }
            if (Vector2.Angle(collision2D.contacts[0].normal, Vector2.down) <= 45f)
            {
                _canMoveUp = false;
            }
            if (Vector2.Angle(collision2D.contacts[0].normal, Vector2.up) <= 45f)
            {
                _canMoveDown = false;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            _canMoveLeft = true;
            _canMoveRight = true;
            _canMoveUp = true;
            _canMoveDown = true;
        }
    }
}

