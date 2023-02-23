using System;
using Project.Scripts.Interactable.Static;
using UnityEngine;

namespace Project.Scripts.Levels._1._1_1
{
    public class Button1_1 : MonoBehaviour
    {
        protected const String PLAYER_LAYER = "Player";

        [SerializeField] protected Animator _animator;
        
        [SerializeField] protected UnlockableObject _door;

        protected bool _pressed;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (_pressed)
            {
                return;
            }
            if (collider2D.gameObject.layer != LayerMask.NameToLayer(PLAYER_LAYER))
            {
                return;
            }

            PressButton();
            _door.Unlock();
        }

        protected void PressButton()
        {
            _pressed = true;
            _animator.SetTrigger("Press");
        }
    }
}
