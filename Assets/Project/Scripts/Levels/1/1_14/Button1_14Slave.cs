using System;
using Project.Scripts.Interactable.Static;
using Project.Scripts.Levels._1._1_1;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1._1_14
{
    public class Button1_14Slave : MonoBehaviour
    {

        private const String PULSAR_BOTON = "PulsarBoton";
        private const String SOLTAR_BOTON = "SoltarBoton";

        [SerializeField] private Animator _animator;

        [SerializeField] private Button1_14Main _main;

        [SerializeField] private UnlockableObject _door;

        private bool _pressed;
        private void OnMouseDown()
        {
            AudioManager.Instance.Play(PULSAR_BOTON);
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
            AudioManager.Instance.Play(SOLTAR_BOTON);
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
