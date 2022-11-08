using System;
using Project.Scripts.Character;
using Project.Scripts.Interactable.Static.RequiredInventory;
using Project.Scripts.Sound;
using UnityEngine;

namespace Project.Scripts.Interactable.PickUps {
    public class PickUp : RequiredInventoryInteractable
    {
        private const String LOOT_PICK_UP_SOUND = "Loot Pick Up Sound";
        
        [SerializeField] protected SpriteRenderer _spriteRenderer;
        [SerializeField] protected CapsuleCollider2D _capsuleCollider2D;
        public override void Interact(Inventory inventory, AudioManager audioManager)
        {
            Debug.Log("Hola2");
            if (inventory.InsertPickUp(this))
            {
                audioManager.Play(LOOT_PICK_UP_SOUND);
                Destroy(_spriteRenderer);
                Destroy(_capsuleCollider2D);
            }
        }
    }
}