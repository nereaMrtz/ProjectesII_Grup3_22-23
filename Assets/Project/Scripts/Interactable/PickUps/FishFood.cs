using Project.Scripts.Character;
using Project.Scripts.Sound;
using UnityEngine;

namespace Project.Scripts.Interactable.PickUps
{
    public class FishFood : PickUp
    {
        [SerializeField] private int _remainingUses;

        public void Use()
        {
            if (_remainingUses != 0)
            {
                _remainingUses--;
                if (_remainingUses == 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
