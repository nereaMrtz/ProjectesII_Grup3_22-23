using System;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Interactable.Static.RequiredInventory.PiggyBank
{
    public class PiggyBank : UnlockableObject
    {
        private const String BROKEN_PIGGY_SOUND = "Broken piggy"; 
        
        [SerializeField] private SpriteRenderer _bill;
        [SerializeField] private BoxCollider2D _boxCollider2D;
        public override void Unlock() 
        {
            AudioManager.Instance.Play(BROKEN_PIGGY_SOUND);
            _bill.gameObject.SetActive(true);
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(_boxCollider2D);
            
        }
    }
}
