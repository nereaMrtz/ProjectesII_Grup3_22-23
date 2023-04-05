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

        private const String PULSAR_BOTON = "Press Button";
        private const String SOLTAR_BOTON = "Release Button";

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
            
            AudioManager.Instance.Play(PULSAR_BOTON, gameObject);
            PressButton();
            _door.CloseDoor();
            StartCoroutine(_resetButton.FlashButton());
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            
            AudioManager.Instance.Play(SOLTAR_BOTON, gameObject);
            PressButton();
        }

        protected void PressButton()
        {
            _pressed = true;
            _animator.SetTrigger("Press");
        }
    }
}
