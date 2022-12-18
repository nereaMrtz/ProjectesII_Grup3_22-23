using System;
using Project.Scripts.Character;
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
                //if (inventorySlots[i].GetPickUp().gameObject.name == "EmptyInventorySlot")
                //{
                  //  continue;
                //}
                GameObject pickUp = inventorySlots[i].GetPickUp().gameObject;
                if (pickUp == _gameObjectToPlace)
                {
                    //gameObject.transform.GetChild(0).gameObject.SetActive(false);
                    
                    inventorySlots[i].EraseChildSprite();
                    
                    //for (int j = 0; j < pickUp.transform.childCount - 1; j++)
                    //{
                     //   Destroy(pickUp.transform.GetChild(j).gameObject);
                    //}
                    
                    //SerializedField hemos quitado el pickup y hemos puesto emptySlot
                    inventorySlots[i].ErasePickUp();
                    
                    pickUp.gameObject.transform.SetParent(transform);
                    pickUp.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    pickUp.gameObject.GetComponent<CapsuleCollider2D>().enabled = true;

                    Vector2 _sumPosition = new Vector2(gameObject.transform.position.x + _offset.x, gameObject.transform.position.y + _offset.y);
                    
                    pickUp.gameObject.transform.position = _sumPosition;

                    return;
                }
            }
            AudioManager.Instance.Play(INCORRECT_SOUND);
        }
    }
}
