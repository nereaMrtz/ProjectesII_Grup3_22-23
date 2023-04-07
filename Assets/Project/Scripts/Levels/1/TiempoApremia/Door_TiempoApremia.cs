using Project.Scripts.Levels._1._1_1;
using UnityEngine;

namespace Project.Scripts.Levels._1.TiempoApremia
{
    public class Door_TiempoApremia : Door
    {
        private int _currentAnimatorStep; 
        
        public void AnimatorStep()
        {
            _currentAnimatorStep = Mathf.Clamp(_currentAnimatorStep + 2, 2, 4);
            _animator.SetTrigger("Step");
            _animator.SetInteger("Animator Step", _currentAnimatorStep);
        }

        public void SetCurrentAnimatorStep(int currentAnimatorStep)
        {
            _currentAnimatorStep = currentAnimatorStep;
        }
    }
}
