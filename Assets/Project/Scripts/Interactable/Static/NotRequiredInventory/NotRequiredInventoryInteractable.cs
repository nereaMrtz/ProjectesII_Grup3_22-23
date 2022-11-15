using System;
using Project.Scripts.Sound;
using UnityEngine;

namespace Project.Scripts.Interactable.Static.NotRequiredInventory
{
    public abstract class NotRequiredInventoryInteractable : InteractableScript
    {
        public abstract void Interact(AudioManager audioManager);
    }
}


