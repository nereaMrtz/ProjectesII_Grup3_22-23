using Project.Scripts.Character;
using UnityEngine;

namespace Project.Scripts.Interactable.PickUps {
    public abstract class PickUp : InteractableScript
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private BoxCollider2D _boxCollider2D;
        public override void Interact(Inventory inventory)
        {
            if (inventory.InsertPickUp(this))
            {
                Destroy(_spriteRenderer);
                Destroy(_boxCollider2D);
            }
        }
    }
}