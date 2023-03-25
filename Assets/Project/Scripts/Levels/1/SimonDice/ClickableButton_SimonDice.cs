using System;
using UnityEngine;

namespace Project.Scripts.Levels._1.SimonDice
{
    public class ClickableButton_SimonDice : MonoBehaviour
    {
        private const int PLAYER_LAYER = 6;
        
        [SerializeField] private Controller_SimonDice _controllerSimonDice;

        [SerializeField] private Animator _animator;
        
        [SerializeField] private int _buttonIndex;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            _animator.SetTrigger("Press");
            _controllerSimonDice.CheckCombination(_buttonIndex);
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            _animator.SetTrigger("Press");
        }
    }
}
