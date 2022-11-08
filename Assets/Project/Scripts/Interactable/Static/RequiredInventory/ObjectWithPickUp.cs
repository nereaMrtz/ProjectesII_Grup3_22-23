using System;
using Project.Scripts.Character;
using Project.Scripts.Interactable.PickUps;
using Project.Scripts.Sound;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Project.Scripts.Interactable.Static.RequiredInventory
{
    public class ObjectWithPickUp : PickUp
    {
        [SerializeField] private PickUp _pickUpAttached;

        [SerializeField] private SpriteRenderer _spriteRenderer;

        [SerializeField] private Inventory _inventory;

        [SerializeField] private Vector3[] _offsets;

        [SerializeField] private float _speed;

        private float _probabilityToGoBack;

        private Vector3 _initialPosition;
        private Vector3 _targetPosition;
        private Vector3 _lastTargetPosition;

        private bool _interacted;
        private bool vectorAsAngle;

        public override void Interact(Inventory inventory, AudioManager audioManager)
        {
            if (!_interacted)
            {
                _interacted = true;
                _pickUpAttached.transform.parent = null;
            }
            else
            {
                _inventory.InsertPickUp(this);
            }
        }

        private void Start()
        {
            transform.position = _initialPosition == Vector3.zero ? _offsets[Random.Range(0, 4)] : _initialPosition;
            _targetPosition = transform.position;
        }

        private void Update()
        {
            if (_offsets.Length == 0)
            {
                return;
            }
            if (Vector3.Distance(transform.position, _targetPosition) <= 0)
            {
                _lastTargetPosition = _targetPosition;
                
                if (_targetPosition == _offsets[0])
                {
                    _targetPosition = _offsets[1];
                }
                else if (_targetPosition == _offsets[^1])
                {
                    _targetPosition = _offsets[^2];
                    
                }
                else
                {
                    for (int i = 0; i < _offsets.Length; i++)
                    {
                        if (_targetPosition != _offsets[i]) continue;
                        int randomNum = Random.Range(0, 2) == 1 ? 1 : -1;
                        _targetPosition = _offsets[randomNum];
                    }
                }
            }
            else
            {
                if (Random.Range(0, 100) < _probabilityToGoBack)
                {
                    (_targetPosition, _lastTargetPosition) = (_lastTargetPosition, _targetPosition);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);    
                }
            }
        }
    }
}


