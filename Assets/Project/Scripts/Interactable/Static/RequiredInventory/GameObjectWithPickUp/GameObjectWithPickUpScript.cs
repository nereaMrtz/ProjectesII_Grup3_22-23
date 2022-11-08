using System;
using Project.Scripts.Character;
using Project.Scripts.Interactable.PickUps;
using Project.Scripts.Sound;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Project.Scripts.Interactable.Static.RequiredInventory.GameObjectWithPickUp
{
    public abstract class GameObjectWithPickUpScript : PickUp
    {
        private const String REQUIRED_INVENTORY_INTERACTABLE = "RequiredInventoryInteractable";
        
        [SerializeField] protected PickUp _pickUpAttached;

        [SerializeField] protected Vector3[] _pickUpAttachedOffsets;

        [SerializeField] protected float _speed;

        protected float _probabilityToGoBack;

        protected Vector3 _initialPosition;
        protected Vector3 _targetPosition;
        protected Vector3 _lastTargetPosition;

        private bool _interacted;
        protected bool _taked;

        public override void Interact(Inventory inventory, AudioManager audioManager)
        {
            if (!_interacted)
            {
                _interacted = true;
                _pickUpAttached.gameObject.layer = LayerMask.NameToLayer(REQUIRED_INVENTORY_INTERACTABLE);
                _pickUpAttached.Interact(inventory, audioManager);
            }
            else
            {
                base.Interact(inventory, audioManager);
                _taked = true;
            }
        }
    }
}


