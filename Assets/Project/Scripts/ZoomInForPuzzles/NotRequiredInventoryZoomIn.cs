using Project.Scripts.Interactable.Static.NotRequiredInventory;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.ZoomInForPuzzles
{
    public class NotRequiredInventoryZoomIn : NotRequiredInventoryInteractable
    {
        [SerializeField] protected GameObject Activate;

        public override void Interact()
        {
            Activate.SetActive(!Activate.activeSelf);

            ChangeZoomInState();
        }

        public void ChangeZoomInState()
        {
            GameManager.Instance.SetZoomInState(!GameManager.Instance.IsInZoomInState());
        }
    }
}
