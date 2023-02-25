using System;
using Project.Scripts.Interactable.Static;
using Project.Scripts.Levels._1._1_1;
using UnityEngine;

namespace Project.Scripts.Levels._1._1_14
{
    public class Button1_14Slave : MonoBehaviour
    {

        [SerializeField] private Animator _animator;

        [SerializeField] private Button1_14Main _main;

        [SerializeField] private UnlockableObject _door;

        private bool _pressed;
        private void OnMouseDown()
        {
            ButtonAction();
            if (!_main.IsPressed())
            {
                return;
            }
            if (_door.IsUnlocked())
            {
                return;
            }
            _door.Unlock();
        }

        private void OnMouseUp()
        {
            ButtonAction();
        }

        private void ButtonAction()
        {
            _pressed = !_pressed;
            ButtonAnimation();
        }

        private void ButtonAnimation()
        {
            _animator.SetTrigger("Press");
        }

        public bool IsPressed()
        {
            return _pressed;
        }

        public void SetPressed(bool pressed)
        {
            _pressed = pressed;
        }
    }
}
