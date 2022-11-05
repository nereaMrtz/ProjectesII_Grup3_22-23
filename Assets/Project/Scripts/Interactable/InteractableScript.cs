using Project.Scripts.Character;
using UnityEngine;


namespace Project.Scripts.Interactable
{
    public abstract class InteractableScript : MonoBehaviour
    {
        public abstract void Interact(Inventory inventory);
    }    
}