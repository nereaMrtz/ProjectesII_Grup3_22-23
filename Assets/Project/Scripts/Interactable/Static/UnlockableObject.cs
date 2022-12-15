using System;
using Project.Scripts.Character;
using Project.Scripts.Interactable.Static.RequiredInventory;
using Project.Scripts.Sound;
using UnityEngine;

namespace Project.Scripts.Interactable.Static
{
    public abstract class UnlockableObject : RequiredInventoryInteractable
    {
        private const String INCORRECT_SOUND = "Incorrect Sound";

        [SerializeField] protected GameObject _keyObject;

        [SerializeField] private bool _destroyObject;
        
        protected bool _unlocked;

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
                
                if (pickUp == _keyObject)
                {
                    if (_destroyObject)
                    {
                        inventorySlots[i].EraseChildSprite();
                        
                        for (int j = 0; j < pickUp.transform.childCount - 1; j++)
                        {
                            Destroy(pickUp.transform.GetChild(j).gameObject);
                        }
                        
                        Destroy(pickUp);
                    }
                    
                    Unlock(audioManager);
                    
                    _unlocked = true;
                    
                    return;
                }
            }
            audioManager.Play(INCORRECT_SOUND);
        }
        protected abstract void Unlock(AudioManager audioManager);
    }
}
