using System;
using Project.Scripts.Sound;
using UnityEngine;

namespace Project.Scripts.Interactable.Static.NotRequiredInventory
{
    public abstract class NotRequiredInventoryInteractable : MonoBehaviour
    {
        public abstract void Interact(AudioManager audioManager);
    }
}