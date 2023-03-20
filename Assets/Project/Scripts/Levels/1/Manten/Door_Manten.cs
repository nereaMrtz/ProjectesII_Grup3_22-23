using Project.Scripts.Levels._1._1_1;

namespace Project.Scripts.Levels._1.Manten 
{
    public class Door_Manten : Door
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