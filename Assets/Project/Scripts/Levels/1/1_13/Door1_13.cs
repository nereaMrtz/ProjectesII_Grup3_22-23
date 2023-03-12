using Project.Scripts.Levels._1._1_1;
using UnityEngine;

namespace Project.Scripts.Levels._1._1_13 
{
    public class Door1_13 : Door
    {
        public void AnimatorStep(bool buttonPressed) {
                        
            if (_unlocked)
            {
                Destroy(this);
            }
            else {
                _animator.SetBool("Open", buttonPressed);
            }            
        }
    }
}