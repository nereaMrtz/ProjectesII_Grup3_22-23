using System;
using Project.Scripts.Levels._1._1_1;
using Project.Scripts.Managers;
using Project.Scripts.UI;
using UnityEngine;

namespace Project.Scripts.Levels._1.NoLoToques
{
    public class Button_NoLoToques : MonoBehaviour
    {
        protected const int PLAYER_LAYER = 6;

        private const String PULSAR_BOTON = "PulsarBoton";
        private const String SOLTAR_BOTON = "SoltarBoton";

        [SerializeField] protected Animator _animator;

        [SerializeField] protected Door _door;

        [SerializeField] private ResetLevelButton _resetButton;

        protected bool _pressed;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (_pressed)
            {
                return;
            }
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            
            AudioManager.Instance.Play(PULSAR_BOTON);
            PressButton();
            _door.CloseDoor();
            StartCoroutine(_resetButton.FlashButton());
        }

        protected void PressButton()
        {
            _pressed = true;
            _animator.SetTrigger("Press");
        }
    }
}
