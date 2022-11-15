using Project.Scripts.Character;
using Project.Scripts.Sound;
using UnityEngine;


namespace Project.Scripts.Interactable.Static.RequiredInventory
{
    public abstract class RequiredInventoryInteractable : InteractableScript
    {
        public abstract void Interact(Inventory inventory, AudioManager audioManager);
    }    
}