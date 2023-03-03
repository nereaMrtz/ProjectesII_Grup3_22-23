using Project.Scripts.Levels._1._1_1;

namespace Project.Scripts.Levels._1._1_13 
{
    public class Door1_13 : Door
    {
        public void AnimatorStep(bool buttonPressed) {

            if (_unlocked) 
            {
                Destroy(this);
            }
            _animator.SetBool("Open", buttonPressed);
        }
    }
}