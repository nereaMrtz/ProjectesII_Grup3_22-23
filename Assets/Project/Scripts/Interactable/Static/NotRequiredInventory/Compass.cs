using Project.Scripts.NoMonoBehaviourClass;
using UnityEngine;

namespace Project.Scripts.Interactable.Static.NotRequiredInventory
{
    public class Compass : NotRequiredInventoryInteractable
    {
        [SerializeField] private Direction[] _directions;

        public override void Interact()
        {
            throw new System.NotImplementedException();
        }

        public Direction[] GetDirections()
        {
            return _directions;
        }
    }
}

