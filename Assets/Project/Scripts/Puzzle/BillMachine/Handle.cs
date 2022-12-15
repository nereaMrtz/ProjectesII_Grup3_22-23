using Project.Scripts.Interactable.PickUps;
using Project.Scripts.Interactable.Static;
using Project.Scripts.Interactable.Static.NotRequiredInventory;
using Project.Scripts.Interactable.Static.RequiredInventory.FromInventoryToWorldSpace;
using Project.Scripts.Managers;
using Unity.VisualScripting;
using UnityEngine;

namespace Project.Scripts.Puzzle.BillMachine
{
    public class Handle : PlacePickupOnWorldSpace
    {
        [SerializeField] private GameObject _panel;

        public override void ActivateBehaviour()
        {
            _panel.layer = LayerMask.NameToLayer("NotRequiredInventoryInteractable");

            Destroy(this);
        }
    }
}