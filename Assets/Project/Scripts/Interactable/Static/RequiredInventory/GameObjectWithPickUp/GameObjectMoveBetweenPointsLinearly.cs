using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Project.Scripts.Interactable.Static.RequiredInventory.GameObjectWithPickUp
{
    public class GameObjectMoveBetweenPointsLinearly : GameObjectWithPickUpScript
    {
    
        private const String REQUIRED_INVENTORY_INTERACTABLE = "RequiredInventoryInteractable";
        
        [SerializeField] private Vector3[] _offsets;

        [SerializeField] private bool _approach;
        private void Start()
        {
            for (int i = 0; i < _offsets.Length; i++)
            {
                _offsets[i] += transform.parent.position;
            }
            transform.position = _initialPosition == Vector3.zero ? _offsets[Random.Range(0, _offsets.Length - 1)] : _initialPosition;
            _targetPosition = transform.position;
        }

        private void Update()
        {
            if (_taked)
            {
                return;
            }
            
            if (_offsets.Length == 0)
            {
                return;
            }

            if (Vector3.Distance(transform.position, _targetPosition) <= 0.01f)
            {
                if (_approach)
                {
                    StartCoroutine(StayStill(2));
                }
                else
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
                            _targetPosition = _offsets[i + randomNum];
                        }
                    }
                }
            }
            else
            {
                if (Random.value < _probabilityToGoBack && !_approach)
                {
                    (_targetPosition, _lastTargetPosition) = (_lastTargetPosition, _targetPosition);
                    _probabilityToGoBack = 0;
                }
                else
                {
                    Vector3 vector = new Vector3(_targetPosition.x - transform.position.x,
                        _targetPosition.y - transform.position.y, 0).normalized;
                
                    _spriteRenderer.flipX = !(vector.x < 0);
                    _pickUpAttached.gameObject.transform.localPosition = _spriteRenderer.flipX ?  _pickUpAttachedOffsets[1] : _pickUpAttachedOffsets[0];
                
                    transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
                    _probabilityToGoBack += Time.deltaTime * 0.001f;
                }
            }
        }

        private IEnumerator StayStill(float seconds)
        {
            _approach = false;
            _pickUpAttached.gameObject.SetActive(true);
            gameObject.layer = LayerMask.NameToLayer(REQUIRED_INVENTORY_INTERACTABLE);
            yield return new WaitForSeconds(seconds);
            gameObject.layer = 0;
            _pickUpAttached.gameObject.SetActive(false);
            _targetPosition = _offsets[Random.Range(0, _offsets.Length - 1)];
        }

        public void SetTargetPosition(Vector3 targetPosition)
        {
            _targetPosition = targetPosition;
        }

        public void SetApproach(bool approach)
        {
            _approach = approach;
        }
    }
}
