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
        private const String REQUIRED_INVENTORY_INTERACTABLE_LAYER = "RequiredInventoryInteractable";
        private const String INCORRECT_SOUND = "Incorrect Sound";
        private const String FISHBOWL_BUBBLES_SOUND = "Fishbowl Bubbles Sound";
        private const String FISH_FOOD_SOUND = "Fish Food Sound";

        [SerializeField] private AudioManager _audioManager; 
        
        [SerializeField] private GameObjectMoveBetweenPointsLinearly _fish;

        [SerializeField] private GameObject _fishFood;

        [SerializeField] private Vector3 _offsetToApproach;

        private bool _playerNear;
        private bool _canSound;
        
        void Start()
        {
            _offsetToApproach += transform.parent.position;
        }

        private void Update()
        {
            if (_fish.GetApproach() || _fish.GetStill())
            {
                if (_fish.GetStill() && _canSound)
                {
                    _audioManager.Play(FISHBOWL_BUBBLES_SOUND);
                    _canSound = false;
                }
                gameObject.layer = 0;
            }
            else
            {
                if (_playerNear)
                {
                    gameObject.layer = LayerMask.NameToLayer(REQUIRED_INVENTORY_INTERACTABLE_LAYER);
                }
            }
        }

        public override void Interact(Inventory inventory, AudioManager audioManager)
        {
            InventorySlot[] inventorySlots = inventory.GetInventorySlots();

            for (int i = 0; i < inventorySlots.Length; i++)
            {
                if (inventorySlots[i].GetPickUp().gameObject.name == "EmptyInventorySlot")
                {
                    continue;
                }
                GameObject pickUp = inventorySlots[i].GetPickUp().gameObject;
                if (pickUp == _fishFood)
                {
                    _canSound = true;
                    _audioManager.Play(FISH_FOOD_SOUND);
                    _fishFood.GetComponent<FishFood>().Use();
                    _fish.SetTargetPosition(_offsetToApproach);
                    _fish.SetApproach(true);
                    return;
                }
            }
            audioManager.Play(INCORRECT_SOUND);
                
                
        }

        public GameObject GetFish()
        {
            return _fish.gameObject;
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer == LayerMask.NameToLayer(PLAYER_LAYER))
            {
                _playerNear = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer == LayerMask.NameToLayer(PLAYER_LAYER))
            {
                _playerNear = false;
                gameObject.layer = 0;
            }
        }
    }
}
