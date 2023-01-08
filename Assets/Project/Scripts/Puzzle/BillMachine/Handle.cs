using Project.Scripts.Interactable.Static.RequiredInventory.FromInventoryToWorldSpace;
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