using Project.Scripts.Sound;
using UnityEngine;

namespace Project.Scripts.Interactable.Static.RequiredInventory.PiggyBank
{
    public class PiggyBank : UnlockableObject
    {
        [SerializeField] private SpriteRenderer _piggyBank;
        [SerializeField] private SpriteRenderer _bill;
        [SerializeField] private BoxCollider2D _boxCollider2D;
        protected override void Unlock(AudioManager audioManager) // Lo q pasara cuando el player tenga en el inventario el martillo
        {
            _piggyBank.sortingOrder = -2;
            _bill.sortingOrder = -2;
            _bill.gameObject.SetActive(true);
            _boxCollider2D.enabled = false;
        }
    }
}
