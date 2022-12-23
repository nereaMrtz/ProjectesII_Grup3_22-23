using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Interactable.Static.RequiredInventory.PiggyBank
{
    public class PiggyBank : UnlockableObject
    {
        [SerializeField] private SpriteRenderer _bill;
        [SerializeField] private BoxCollider2D _boxCollider2D;
        protected override void Unlock() // Lo q pasara cuando el player tenga en el inventario el martillo
        {
            _spriteRenderer.sortingOrder = -2;
            _bill.sortingOrder = -2;
            _bill.gameObject.SetActive(true);
            GetComponent<SpriteRenderer>().enabled = false;
            _boxCollider2D.enabled = false;
            _interactableAreaPanel.SetActive(false);
            _pointButton.SetActive(false);
        }
    }
}
