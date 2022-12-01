using System;
using Project.Scripts.Character;
using Project.Scripts.Interactable.Static.RequiredInventory;
using Project.Scripts.Sound;
using Project.Scripts.UI;
using UnityEngine;

namespace Project.Scripts.Interactable.PickUps {
    public class PickUp : RequiredInventoryInteractable, ICombinePickUps
    {
        private const String LOOT_PICK_UP_SOUND = "Loot Pick Up Sound";
        
        [SerializeField] protected SpriteRenderer _spriteRenderer;
        
        [SerializeField] protected CapsuleCollider2D _capsuleCollider2D;
        
        [SerializeField] private BoxCollider2D _commentTrigger;

        [SerializeField] private GameObject _circleFeedback;
        public override void Interact(Inventory inventory, AudioManager audioManager)
        {
            if (inventory.InsertPickUp(this))
            {
                //Destroy(_objectTip.gameObject);
                audioManager.Play(LOOT_PICK_UP_SOUND);
                _spriteRenderer.enabled = false;
                _capsuleCollider2D.enabled = false;
                _commentTrigger.enabled = false;
                _circleFeedback.SetActive(false);
                
                //transform.GetChild(0).gameObject.SetActive(false);
            }
        }

        public PickUp CombinePickUps(PickUp pickUp)
        {
            throw new NotImplementedException();
        }
    }
}