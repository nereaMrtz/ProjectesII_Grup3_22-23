using Project.Scripts.Interactable.Static.NotRequiredInventory;
using Project.Scripts.Managers;
using Project.Scripts.Sound;
using UnityEngine;

namespace Project.Scripts.ZoomInForPuzzles
{
    public class ZoomIn : NotRequiredInventoryInteractable
    {
        [SerializeField] private GameObject Activate;

        public override void Interact(AudioManager audioManager)
        {
            Activate.SetActive(!Activate.activeSelf);

            GameManager.Instance.SetZoomInState(!GameManager.Instance.IsInZoomInState());
        }
    }
}
