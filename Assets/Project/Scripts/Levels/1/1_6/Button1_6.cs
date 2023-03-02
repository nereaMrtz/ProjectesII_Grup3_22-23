using System;
using Project.Scripts.Levels._1._1_1;
using UnityEngine;

namespace Project.Scripts.Levels._1._1_6
{
    public class Button1_6 : MonoBehaviour
    {
        protected const String PLAYER_LAYER = "Player";

        [SerializeField] protected SpriteRenderer _spriteRenderer;

        [SerializeField] protected Animator _animator;

        [SerializeField] protected Door _door;

        [SerializeField] protected bool _pressed;

        [SerializeField] protected Sprite _openDoor;

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
            _door.CloseDoor();
            _spriteRenderer.sprite = _openDoor;
        }

        protected void PressButton()
        {
            _pressed = true;
            _animator.SetTrigger("Press");
        }
    }
}
