using UnityEngine;

namespace Project.Scripts.Interactable.PickUps {
    public abstract class PickUp : InteractableScript
    {
        public abstract void DoItYourself();
        public override void Interact()
        {
            Destroy(gameObject);
        }
    }
}