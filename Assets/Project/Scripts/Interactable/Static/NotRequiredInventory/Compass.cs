using System;
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
        /*private void OnBecameVisible()
        {
            Debug.Log("Hola");
            //HoverTipManager.OnPlayerTriggerEnter(_tipText, _gameObjectAttached.transform.position);
        }

        private void OnBecameInvisible()
        {
            Debug.Log("Adios");
            //HoverTipManager.OnPlayerTriggerExit();
        }*/

        public Direction[] GetDirections()
        {
            return _directions;
        }
    }
}

