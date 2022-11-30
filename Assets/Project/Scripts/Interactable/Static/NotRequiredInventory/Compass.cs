using System;
using Project.Scripts.NoMonoBehaviourClass;
using Project.Scripts.Sound;
using UnityEngine;

namespace Project.Scripts.Interactable.Static.NotRequiredInventory
{
    public class Compass : MonoBehaviour
    {
        [SerializeField] private Direction[] _directions;

        public Direction[] GetDirections()
        {
            return _directions;
        }
    }
}

