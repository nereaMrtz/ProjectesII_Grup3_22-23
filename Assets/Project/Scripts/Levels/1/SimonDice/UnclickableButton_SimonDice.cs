using UnityEngine;

namespace Project.Scripts.Levels._1.SimonDice
{
    public class UnclickableButton_SimonDice : MonoBehaviour
    {

        [SerializeField] private Animator _animator;

        public void PressButton()
        {
            _animator.SetTrigger("Press");
        }
    }
}
