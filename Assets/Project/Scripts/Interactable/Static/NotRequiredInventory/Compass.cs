using Project.Scripts.NoMonoBehaviourClass;
using Project.Scripts.Sound;
using UnityEngine;

namespace Project.Scripts.Interactable.Static.NotRequiredInventory
{
    public class Compass : NotRequiredInventoryInteractable
    {
        [SerializeField] private Direction[] _directions;

        public override void Interact(AudioManager audioManager)
        {
            throw new System.NotImplementedException();
        }

        public Direction[] GetDirections()
        {
            return _directions;
        }
    }
}

