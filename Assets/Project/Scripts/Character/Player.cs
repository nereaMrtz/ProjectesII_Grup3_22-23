using System;
using UnityEngine;
using Project.Scripts.Interactable.Static.NotRequiredInventory;
using Project.Scripts.Interactable.Static.RequiredInventory;
using Project.Scripts.Managers;
using UnityEngine.AI;
using Vector2 = UnityEngine.Vector2;

namespace Project.Scripts.Character
{
    public class Player : MonoBehaviour
    {
        private const String STEPS_SOUND_CLIP_NAME = "Steps Sound";

        private Animator anim;

        private const string REQUIRED_INVENTORY_INTERACTABLE_LAYER = "RequiredInventoryInteractable";
        private const string NOT_REQUIRED_INVENTORY_INTERACTABLE_LAYER = "NotRequiredInventoryInteractable";
        
        [SerializeField] private GameObject _pauseMenuPanel;

        [SerializeField] private Inventory _inventory;

        [SerializeField] private DrugEffect _drugEffect;

        [SerializeField] private Transform _targetTransform;

        [SerializeField] private NavMeshAgent _agent;

        private GameObject _gameObjectToInteract;
        
        private float _distanceToInteractWithObject;

        private bool _moving = true;
        private bool _interactionStarted; 
        
        void Start()
        {
            NavMeshManager.Instance.Bake();
            _agent.updateRotation = false;
            _agent.updateUpAxis = false;
            _targetTransform.position = transform.position;
        }

        void Update()
        {
            
            if ((Input.GetKey(KeyCode.Escape) && !_pauseMenuPanel.activeSelf))
            {
                _pauseMenuPanel.SetActive(true);
            }
            
            if (_drugEffect.IsChangingPeriod() || _pauseMenuPanel.activeSelf)
            {
                return;
            }
            
            Controls();
        }

        private void Controls()
        {
            if (GameManager.Instance.IsInZoomInState())
            {
                _targetTransform.position = transform.position;
                AudioManager.Instance.Pause(STEPS_SOUND_CLIP_NAME);
                return;
            }

            MovementController();
            
            InteractionController();
        }

        private void MovementController()
        {
            if (_agent.velocity.magnitude != 0)
            {
                _moving = true;
                anim.SetBool("isMoving", true);
                AudioManager.Instance.UnPause(STEPS_SOUND_CLIP_NAME);
            }
            else if (_moving && _agent.velocity.magnitude == 0)
            {
                _moving = false;
                anim.SetBool("isMoving", false);
                AudioManager.Instance.Pause(STEPS_SOUND_CLIP_NAME);
                _targetTransform.position = transform.position;
                return;   
            }
            
            Movement();
        }

        private void InteractionController()
        {
            if (!_interactionStarted)
            {
                return;
            }
            
            if (Vector2.Distance(transform.position, _gameObjectToInteract.transform.position) < _distanceToInteractWithObject)
            {
                InteractWithObject();
            }
            else if (_targetTransform.position != _gameObjectToInteract.transform.position)
            {
                _gameObjectToInteract = null;
                _interactionStarted = false;
            }
        }

        private void InteractWithObject() {
            
            if (_gameObjectToInteract.layer == LayerMask.NameToLayer(REQUIRED_INVENTORY_INTERACTABLE_LAYER))
            {
                _gameObjectToInteract.GetComponent<RequiredInventoryInteractable>().Interact(_inventory);
            }
            else if (_gameObjectToInteract.layer == LayerMask.NameToLayer(NOT_REQUIRED_INVENTORY_INTERACTABLE_LAYER))
            {
                _gameObjectToInteract.GetComponent<NotRequiredInventoryInteractable>().Interact();
            }

            _targetTransform.position = transform.position;
            _gameObjectToInteract = null;
            _interactionStarted = false;
        }

        public void DrugControls()
        {
            _drugEffect.ChangeState();
            _targetTransform.position = transform.position;
        }

        private void Movement()
        {
            _agent.SetDestination(_targetTransform.position);
        }
        
        public void SetGameObjectAndHisDistanceToInteract(GameObject gameObjectToInteract, float distanceToInteract)
        {
            _interactionStarted = true;
            _gameObjectToInteract = gameObjectToInteract;
            _distanceToInteractWithObject = distanceToInteract;
            _targetTransform.position = _gameObjectToInteract.transform.position;
            GameManager.Instance.SetInteractableClicked(true);
        }
    }
}