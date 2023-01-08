using Project.Scripts.Character;
using Project.Scripts.Interactable.Static.RequiredInventory;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.ZoomInForPuzzles
{
    public class RequiredInventoryZoomIn : RequiredInventoryInteractable
    {
        [SerializeField] protected GameObject Activate;

        public override void Interact(Inventory inventory)
        {
            Activate.SetActive(!Activate.activeSelf);

            GameManager.Instance.SetZoomInState(!GameManager.Instance.IsInZoomInState());
        }
    }
}
