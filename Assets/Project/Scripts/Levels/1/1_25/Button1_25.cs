using System;
using Project.Scripts.Interactable.Static;
using UnityEngine;

namespace Project.Scripts.Levels._1._1_25
{
    public class Button1_25 : MonoBehaviour
    {
        [SerializeField] protected Animator _animator;
        
        [SerializeField] protected UnlockableObject _door;

        [SerializeField] protected bool _pressed;

        private void OnMouseDown()
        {
            if (!_door.IsUnlocked())
            {
                _door.Unlock();
            }
            ButtonAction();
        }

        private void OnMouseUp()
        {
            ButtonAction();
        }

        protected void ButtonAction()
        {
            _pressed = !_pressed;
            ButtonAnimation();
        }

        private void ButtonAnimation()
        {
            _animator.SetTrigger("Press");
        }
    }
}
