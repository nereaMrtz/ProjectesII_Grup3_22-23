using Project.Scripts.Character;
using Project.Scripts.Managers;
using UnityEngine;


namespace Project.Scripts.Interactable.Static.RequiredInventory
{
    public abstract class RequiredInventoryInteractable : InteractableScript
    {
        public abstract void Interact(Inventory inventory);
    }    
}