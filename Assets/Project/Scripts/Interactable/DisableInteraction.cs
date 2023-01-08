using System;
using Project.Scripts.Interactable.Static.NotRequiredInventory;
using UnityEngine;

namespace Project.Scripts.Interactable
{
    public class DisableInteraction : MonoBehaviour
    {
        private void OnMouseDown()
        {
            gameObject.layer = 0;
        }
    }
}
