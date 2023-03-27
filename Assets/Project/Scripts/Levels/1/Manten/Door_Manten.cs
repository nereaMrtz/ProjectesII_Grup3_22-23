using Project.Scripts.Levels._1._1_1;

namespace Project.Scripts.Levels._1.Manten 
{
    public class Door_Manten : Door
    {

        private bool _startOpening;
        
        public void AnimatorStep(bool buttonPressed) {
                        
            if (_unlocked)
            {
                Destroy(this);
            }
            else {
                if (!buttonPressed)
                {
                    _animator.SetTrigger("Reset");
                }
                _animator.SetBool("Open", buttonPressed);    
            }            
        }

        public bool IsStartOpening()
        {
            return _startOpening;
        }

        public void SetStartOpening(bool startOpening)
        {
            _startOpening = startOpening;
        }
    }
}