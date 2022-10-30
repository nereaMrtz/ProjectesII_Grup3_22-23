using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Scripts.Sound;
using Unity.VisualScripting;

namespace Project.Scripts.Character
{
    public class Player : MonoBehaviour
    {
        private const String STEPS_SOUND_CLIP_NAME = "Steps Sound";

        [SerializeField] private AudioManager _audioManager;
        
        [SerializeField] private Rigidbody2D _rigidbody2D;

        [SerializeField] private float _currentSpeed = 75;

        void Start()
        {
            _audioManager = FindObjectOfType<AudioManager>();
        }

        void Update()
        {
            Controls();

            if (Input.GetKeyUp(KeyCode.Space))
            {
                _rigidbody2D.AddForce(Vector2.right * 70f, ForceMode2D.Impulse);
            }
        }

        private void FixedUpdate()
        {
            Movement();
        }
        
        private void Movement()
        {
            float movementX = 0;
            float movementY = 0;
            
            if (Input.GetKey(KeyCode.A))
            {
                movementX = -1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                movementX = 1;
            }
            if (Input.GetKey(KeyCode.W))
            {
                movementY = 1;
            }
            if (Input.GetKey(KeyCode.S))
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
    }
}

