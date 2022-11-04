using System;
using UnityEngine;
using Project.Scripts.Sound;
using Project.Scripts.Interactable;

namespace Project.Scripts.Character
{
    public class Player : MonoBehaviour
    {
        private const String STEPS_SOUND_CLIP_NAME = "Steps Sound";

        private const string INTERACTABLE_LAYER = "Interactable";

        [SerializeField] private AudioManager _audioManager;
        
        [SerializeField] private Rigidbody2D _rigidbody2D;

        [SerializeField] private Inventory _inventory;

        [SerializeField] private float _currentSpeed = 75;

        private float _movementX;
        private float _movementY;

        private LayerMask _interactableMask;

        void Start()
        {
            _interactableMask = LayerMask.GetMask(INTERACTABLE_LAYER);
            _audioManager = FindObjectOfType<AudioManager>();
        }

        void Update()
        {
            Controls();
        }

        private void FixedUpdate()
        {
            Movement();
            
            if (Input.GetKeyUp(KeyCode.Space))
            {
                _rigidbody2D.AddForce(Vector2.right * 70f, ForceMode2D.Impulse);
            }
        }
        
        private void Movement()
        {
            Vector2 movementDirection = new Vector3(_movementX, _movementY).normalized;
            _rigidbody2D.AddForce(movementDirection * _currentSpeed, ForceMode2D.Force);

            if (movementDirection.x != 0 || movementDirection.y != 0)
            {
                _audioManager.UnPause(STEPS_SOUND_CLIP_NAME);
            }
            else
            {
                _audioManager.Pause(STEPS_SOUND_CLIP_NAME);
            }
        }
        

        private void Controls()
        {
            MovementControls();

            InteractControls();
        }

        private void InteractControls() {

            if (Input.GetKeyDown(KeyCode.E))
            {
                Collider2D interactCast = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), 1, 128);

                if (interactCast == true)
                {
                    interactCast.gameObject.GetComponent<InteractableScript>().Interact();
                }
            }
        }

        private void MovementControls()
        {
            _movementX = 0;
            _movementY = 0;
            if (Input.GetKey(KeyCode.A))
            {
                _movementX = -1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                _movementX = 1;
            }
            if (Input.GetKey(KeyCode.W))
            {
                _movementY = 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                _movementY = -1;
            }
        }
    }
}

