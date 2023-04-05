using System;
using Project.Scripts.Interactable.Static;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1.Pulsalo
{
    public class Button_Pulsalo : MonoBehaviour
    {

        private const String PULSAR_BOTON = "PulsarBoton";
        private const String SOLTAR_BOTON = "SoltarBoton";
        
        [SerializeField] protected Animator _animator;
        
        [SerializeField] protected UnlockableObject _door;

        protected bool _pressed;

        private void OnMouseDown()
        {
            if (!_door.IsUnlocked())
            {
                _door.Unlock();
            }
            AudioManager.Instance.Play(PULSAR_BOTON,gameObject);
            ButtonAction();
        }

        private void OnMouseUp()
        {
            AudioManager.Instance.Play(SOLTAR_BOTON, gameObject);
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
