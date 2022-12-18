using System;
using System.Collections;
using System.Numerics;
using UnityEngine;
using Project.Scripts.Interactable.Static.NotRequiredInventory;
using Project.Scripts.Interactable.Static.RequiredInventory;
using Project.Scripts.Managers;
using Project.Scripts.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace Project.Scripts.Character
{
    public class Player : MonoBehaviour
    {
        private const String STEPS_SOUND_CLIP_NAME = "Steps Sound";

        private const string REQUIRED_INVENTORY_INTERACTABLE_LAYER = "RequiredInventoryInteractable";
        private const string NOT_REQUIRED_INVENTORY_INTERACTABLE_LAYER = "NotRequiredInventoryInteractable";
        
        [SerializeField] private GameObject _pauseMenuPanel;

        [SerializeField] private Inventory _inventory;

        [SerializeField] private DrugEffect _drugEffect;

        [SerializeField] private Transform _targetTransform;

        [SerializeField] private NavMeshAgent _agent;

        [SerializeField] private GameObject _gameObjectToInteract;

        private Vector3 _lastTargetPosition;
        
        private float _distanceToInteractWithObject;

        private bool _moving;
        [SerializeField] private bool _interactionStarted; 
        
        void Start()
        {
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
            
            if (_drugEffect.GetBetweenChangePeriod() || _pauseMenuPanel.activeSelf)
            {
                return;
            }
            
            Controls();
        }

        private void Controls()
        {
            if (GameManager.Instance.IsInZoomInState())
            {
                AudioManager.Instance.Pause(STEPS_SOUND_CLIP_NAME);
                return;
            }

            float distanceBetweenPlayerAndTargetPosition =
                Vector2.Distance(transform.position, _targetTransform.position);
            
            if (distanceBetweenPlayerAndTargetPosition < 0.01f || (_moving && _agent.velocity.magnitude == 0))
            {
                _moving = false;
                _targetTransform.position = transform.position;
                AudioManager.Instance.Pause(STEPS_SOUND_CLIP_NAME);
                Debug.Log("Short Distance or Too close");
                return;   
            }
            
            Movement();
            AudioManager.Instance.UnPause(STEPS_SOUND_CLIP_NAME);

            if (!_interactionStarted)
            {
                Debug.Log("Not Interacting");
                return;
            }
            
            Debug.Log(Vector2.Distance(transform.position, _gameObjectToInteract.transform.position));
            
            if (Vector2.Distance(transform.position, _gameObjectToInteract.transform.position) < _distanceToInteractWithObject)
            {
                InteractWithObject();
            }
            else if (_lastTargetPosition != _targetTransform.position)
            {
                _interactionStarted = false;
                _gameObjectToInteract = null;
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

            _interactionStarted = false;
        }

        public void DrugControls()
        {
            _drugEffect.ChangeState();
            _targetTransform.position = transform.position;
        }

        private void Movement()
        {
            _moving = true;
            _agent.SetDestination(_targetTransform.position);
        }
        
        public void SetGameObjectAndHisDistanceToInteract(GameObject gameObjectToInteract, float distanceToInteract)
        {
            Debug.Log("StartInteraction");
            _interactionStarted = true;
            _gameObjectToInteract = gameObjectToInteract;
            _distanceToInteractWithObject = distanceToInteract;
        }

        public void SetLastTargetPosition(Vector3 lastTargetPosition)
        {
            _lastTargetPosition = lastTargetPosition;
        }
    }
}

