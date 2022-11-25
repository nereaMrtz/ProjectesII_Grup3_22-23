using System;
using UnityEngine;
using Project.Scripts.Sound;
using Project.Scripts.Interactable.Static.NotRequiredInventory;
using Project.Scripts.Interactable.Static.RequiredInventory;
using Project.Scripts.Managers;

namespace Project.Scripts.Character
{
    public class Player : MonoBehaviour
    {
        private const String STEPS_SOUND_CLIP_NAME = "Steps Sound";

        private const string REQUIRED_INVENTORY_INTERACTABLE_LAYER = "RequiredInventoryInteractable";
        private const string NOT_REQUIRED_INVENTORY_INTERACTABLE_LAYER = "NotRequiredInventoryInteractable";

        [SerializeField] private AudioManager _audioManager;
        
        [SerializeField] private Rigidbody2D _rigidbody2D;
        
        [SerializeField] private GameObject _pauseMenuPanel;

        [SerializeField] private Inventory _inventory;

        [SerializeField] private DrugEffect _drugEffect;

        [SerializeField] private float _currentSpeed = 75;

        private Vector2 movementDirection;

        private float _movementX;
        private float _movementY;

        private LayerMask _requiredInventoryInteractableMask;
        private LayerMask _notRequiredInventoryInteractableMask;
        
        void Start()
        {
            _requiredInventoryInteractableMask = LayerMask.GetMask(REQUIRED_INVENTORY_INTERACTABLE_LAYER);
            _notRequiredInventoryInteractableMask = LayerMask.GetMask(NOT_REQUIRED_INVENTORY_INTERACTABLE_LAYER);
            _audioManager = FindObjectOfType<AudioManager>();
        }

        void Update()
        {
            if ((Input.GetKey(KeyCode.Escape) && !_pauseMenuPanel.activeSelf))
            {
                _pauseMenuPanel.SetActive(true);
            }
            
            if (_drugEffect.GetBetweenChangePeriod() || _pauseMenuPanel.activeSelf)
            {
                return;
            }
            Controls();
        }

        private void FixedUpdate()
        {
            if (_drugEffect.GetBetweenChangePeriod())
            {
                _audioManager.Pause(STEPS_SOUND_CLIP_NAME);
                return;
            }
            Movement();
            
            if (Input.GetKeyUp(KeyCode.Space))
            {
                _rigidbody2D.AddForce(Vector2.right * 70f, ForceMode2D.Impulse);
            }
        }
        
        private void Movement()
        {
            movementDirection = new Vector3(_movementX, _movementY).normalized;
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
            InteractControls();

            if (!GameManager.Instance.IsInZoomInState())
            {
                DrugControls();
                
                MovementControls();
            }
        }

        private void InteractControls() {

            if (Input.GetKeyDown(KeyCode.E))
            {
                Collider2D interactCast = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), 1, _requiredInventoryInteractableMask + _notRequiredInventoryInteractableMask);

                if (interactCast == true)
                {
                    if (interactCast.gameObject.layer == LayerMask.NameToLayer(REQUIRED_INVENTORY_INTERACTABLE_LAYER))
                    {
                        interactCast.gameObject.GetComponent<RequiredInventoryInteractable>().Interact(_inventory, _audioManager);
                    }
                    else if (interactCast.gameObject.layer == LayerMask.NameToLayer(NOT_REQUIRED_INVENTORY_INTERACTABLE_LAYER))
                    {
                        interactCast.gameObject.GetComponent<NotRequiredInventoryInteractable>().Interact(_audioManager);
                    }
                }
            }
        }

        private void DrugControls()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _drugEffect.ChangeState(_audioManager);
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

