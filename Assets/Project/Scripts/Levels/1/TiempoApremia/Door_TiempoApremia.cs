using Project.Scripts.Levels._1._1_1;

namespace Project.Scripts.Levels._1.TiempoApremia
{
    public class Door_TiempoApremia : Door
    {
        
        public void AnimatorStep(bool pressing) {
                        
            _animator.SetBool("Open", pressing);          
        }
    }
}
