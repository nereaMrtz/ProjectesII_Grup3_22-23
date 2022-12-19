using Project.Scripts.Interactable.Static;
using UnityEngine;

namespace Project.Scripts.Puzzle.BillMachine
{
    public class ChangeBillForCoin : UnlockableObject
    {
        [SerializeField] private GameObject _coin;

        protected override void Unlock()
        {
            _coin.SetActive(true);

            gameObject.layer = 0;
        }
    }
}
