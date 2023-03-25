using Project.Scripts.Character;

namespace Project.Scripts.Interactable.Static.RequiredInventory
{
    public abstract class RequiredInventoryInteractable : InteractableScript
    {
        public abstract void Interact(Inventory inventory);
    }    
}