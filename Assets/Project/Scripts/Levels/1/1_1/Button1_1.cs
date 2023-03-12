using System;
using Project.Scripts.Interactable.Static;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1._1_1
{
    public class Button1_1 : MonoBehaviour
    {
        private const int PLAYER_LAYER = 6;

        private const String PULSAR_BOTON = "PulsarBoton";
        private const String SOLTAR_BOTON = "SoltarBoton";
        
        [SerializeField] protected Animator _animator;
        
        [SerializeField] protected UnlockableObject _door;

        protected bool _pressed;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            AudioManager.Instance.Play(PULSAR_BOTON);
            ButtonAction();
            if (_door.IsUnlocked())
            {
                return;
            }
            _door.Unlock();
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            AudioManager.Instance.Play(SOLTAR_BOTON);
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
