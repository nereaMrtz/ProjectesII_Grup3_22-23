using Project.Scripts.Interactable.Static;
using UnityEngine;

namespace Project.Scripts.Levels._1._1_1
{
    public class Button1_1 : MonoBehaviour
    {
        [SerializeField] protected Animator _animator;
        
        [SerializeField] protected UnlockableObject _door;

        [SerializeField] protected bool _pressed;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != 6)
            {
                return;
            }
            ButtonAction();
            if (_door.IsUnlocked())
            {
                return;
            }
            _door.Unlock();
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != 6)
            {
                return;
            }
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
