using System;
using System.Security.Cryptography;
using Project.Scripts.Character;
using Project.Scripts.Interactable.PickUps;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Interactable.Static.RequiredInventory.FromInventoryToWorldSpace
{
        
    public abstract class PlacePickupOnWorldSpace : RequiredInventoryInteractable
    {
        private const String INCORRECT_SOUND = "Incorrect Sound";

        [SerializeField] private GameObject _gameObjectToPlace;

        [SerializeField] private Vector2 _offset;
        
        public override void Interact(Inventory inventory)
        {
            InventorySlot[] inventorySlots = inventory.GetInventorySlots();
            
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                GameObject pickUp = inventorySlots[i].GetPickUp().gameObject;
                if (pickUp == _gameObjectToPlace)
                {
                    inventorySlots[i].EraseChildSprite();
                    
                    inventorySlots[i].ErasePickUp();
                    
                    pickUp.gameObject.transform.SetParent(transform);
                    pickUp.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    pickUp.gameObject.GetComponent<CapsuleCollider2D>().enabled = true;

                    Vector2 _sumPosition = new Vector2(gameObject.transform.position.x + _offset.x, gameObject.transform.position.y + _offset.y);
                    
                    pickUp.gameObject.transform.position = _sumPosition;
                    
                    Destroy(pickUp.GetComponent<PickUp>());
                    
                    Destroy(pickUp.GetComponent<CapsuleCollider2D>());
                    
                    ActivateBehaviour();

                    return;
                }
            }
            AudioManager.Instance.Play(INCORRECT_SOUND);
        }

        public abstract void ActivateBehaviour();
    }
}
