using System;
using Project.Scripts.Character;
using Project.Scripts.Interactable.PickUps;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Project.Scripts.Puzzle.Labyrinth
{
    public class LabyrinthWithInventoryObject : LabyrinthScript
    {
        [SerializeField] private PickUp _objectNeeded;

        [SerializeField] private Inventory _inventory;

        [SerializeField] private GameObject _gameObjectToActivate;

        private InventorySlot _objectNeededInventorySlot;

        private void OnEnable()
        {
            InventorySlot[] inventorySlots = _inventory.GetInventorySlots();
            
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                if (inventorySlots[i].GetPickUp().gameObject.name == "EmptyInventorySlot")
                {
                    continue;
                }
                
                GameObject pickUp = inventorySlots[i].GetPickUp().gameObject;
                
                if (_objectNeeded != pickUp)
                {
                    continue;
                }
                _gameObjectToActivate.SetActive(true);
                _objectNeededInventorySlot = inventorySlots[i];
                _objectNeededInventorySlot.EraseChildSprite();
            }
        }

        private void OnDisable()
        {
            _objectNeededInventorySlot.SetPickUp(_objectNeeded);
        }

        private new void Update()
        {
            base.Update();

            if (_completed)
            {
                Destroy(_objectNeeded);
            }
        }
    }
}
