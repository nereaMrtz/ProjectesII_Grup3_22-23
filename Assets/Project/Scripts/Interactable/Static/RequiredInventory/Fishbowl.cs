using System;
using Project.Scripts.Character;
using Project.Scripts.Interactable.PickUps;
using Project.Scripts.Interactable.Static.RequiredInventory.GameObjectWithPickUp;
using Project.Scripts.Sound;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.Interactable.Static.RequiredInventory
{
    public class Fishbowl : RequiredInventoryInteractable
    {
        private const String PLAYER_LAYER = "Player";
        private const String REQUIRED_INVENTORY_INTERACTABLE = "RequiredInventoryInteractable";
        
        [SerializeField] private GameObjectMoveBetweenPointsLinearly _fish;

        [SerializeField] private GameObject _fishFood;

        [SerializeField] private Vector3 _offsetToApproach;

        private bool _near;
        void Start()
        {
            _offsetToApproach += transform.parent.position;
        }

        private void Update()
        {
            if (_fish.GetApproach() || _fish.GetStill())
            {
                gameObject.layer = 0;
            }
            else
            {
                if (_near)
                {
                    gameObject.layer = LayerMask.NameToLayer(REQUIRED_INVENTORY_INTERACTABLE);
                }
            }
        }

        public override void Interact(Inventory inventory, AudioManager audioManager)
        {
            InventorySlot[] inventorySlots = inventory.GetInventorySlots();

            for (int i = 0; i < inventorySlots.Length; i++)
            {
                if (inventorySlots[i].GetPickUp().gameObject == null)
                {
                    break;
                }
                GameObject pickUp = inventorySlots[i].GetPickUp().gameObject;
                if (pickUp == _fishFood)
                {
                    _fishFood.GetComponent<FishFood>().Use();
                    _fish.SetTargetPosition(_offsetToApproach);
                    _fish.SetApproach(true);
                    return;
                }
            }
            //SHOW POP UP
                
                
        }

        public GameObject GetFish()
        {
            return _fish.gameObject;
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer == LayerMask.NameToLayer(PLAYER_LAYER))
            {
                _near = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer == LayerMask.NameToLayer(PLAYER_LAYER))
            {
                _near = false;
                gameObject.layer = 0;
            }
        }
    }
}
