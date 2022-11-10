using Project.Scripts.NoMonoBehaviourClass;
using Project.Scripts.Sound;
using UnityEngine;

namespace Project.Scripts.Interactable.Static.NotRequiredInventory
{
    public class Compass : NotRequiredInventoryInteractable
    {
        [SerializeField] private Direction[] _directions;

        [SerializeField] private GameObject _compassInstructions;

        public override void Interact(AudioManager audioManager)
        {
            _compassInstructions.SetActive(true);
        }

        public Direction[] GetDirections()
        {
            return _directions;
        }
    }
}

