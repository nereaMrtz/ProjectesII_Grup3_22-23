using Project.Scripts.Character;
using UnityEngine;

namespace Project.Scripts.Interactable.PickUps {
    public abstract class PickUp : InteractableScript
    {
        [SerializeField] private Inventory _playerInventory;
        public override void Interact()
        {
            if (_playerInventory.InsertPickUp(this))
            {
                
            }
        }
    }
}