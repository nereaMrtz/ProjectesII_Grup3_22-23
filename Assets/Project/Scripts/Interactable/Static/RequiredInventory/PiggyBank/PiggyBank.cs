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
            _bill.gameObject.SetActive(true);
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(_boxCollider2D);
            GetPointButton().SetActive(false);
        }
    }
}
