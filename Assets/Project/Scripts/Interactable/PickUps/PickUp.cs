using System;
using Project.Scripts.Character;
using Project.Scripts.Interactable.Static.RequiredInventory;
using Project.Scripts.Sound;
using UnityEngine;

namespace Project.Scripts.Interactable.PickUps {
    public abstract class PickUp : RequiredInventoryInteractable
    {
        private const String LOOT_PICK_UP_SOUND = "Loot Pick Up Sound";
        
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private BoxCollider2D _boxCollider2D;
        public override void Interact(Inventory inventory, AudioManager audioManager)
        {
            if (inventory.InsertPickUp(this))
            {
                audioManager.Play(LOOT_PICK_UP_SOUND);
                Destroy(_spriteRenderer);
                Destroy(_boxCollider2D);
            }
        }
    }
}