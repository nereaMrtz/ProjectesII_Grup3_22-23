using System;
using Project.Scripts.Interactable.Static;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Puzzle.BillMachine
{
    public class ChangeBillForCoin : UnlockableObject
    {
        private const String BILL_MACHINE_SOUND = "BillMachine";
        
        [SerializeField] private GameObject _coin;

        public override void Unlock()
        {
            AudioManager.Instance.Play(BILL_MACHINE_SOUND);
            _coin.SetActive(true);
            gameObject.layer = 0;
        }
    }
}
