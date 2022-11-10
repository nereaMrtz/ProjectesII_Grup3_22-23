using System;
using Project.Scripts.Character;
using Project.Scripts.Interactable.Static.RequiredInventory;
using Project.Scripts.Sound;
using UnityEngine;

namespace Project.Scripts.Interactable.PickUps {
    public class PickUp : RequiredInventoryInteractable, ICombinePickUps
    {
        private const String LOOT_PICK_UP_SOUND = "Loot Pick Up Sound";
        
        [SerializeField] protected SpriteRenderer _spriteRenderer;
        [SerializeField] protected CapsuleCollider2D _capsuleCollider2D;
        public override void Interact(Inventory inventory, AudioManager audioManager)
        {
            if (inventory.InsertPickUp(this))
            {
                audioManager.Play(LOOT_PICK_UP_SOUND);
                _spriteRenderer.enabled = false;
                Destroy(_capsuleCollider2D);
            }
        }

        public PickUp CombinePickUps(PickUp pickUp)
        {
            throw new NotImplementedException();
        }
    }
}