using System;
using UnityEngine;

namespace Project.Scripts.Levels._1._1_7 {

    public class Button1_7 : MonoBehaviour
    {
        protected const String PLAYER_LAYER = "Player";

        [SerializeField] protected Animator _animator;

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

            ChangeButtonState();
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != LayerMask.NameToLayer(PLAYER_LAYER))
            {
                return;
            }

            ChangeButtonState();
        }

        protected void ChangeButtonState()
        {
            _pressed = !_pressed;
            _animator.SetTrigger("Press");
        }
    }

}