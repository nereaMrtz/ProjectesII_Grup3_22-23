using Project.Scripts.Levels._1._1_1;

namespace Project.Scripts.Levels._1.Equacion
{
    public class Door_Equacion : Door
    {
        public void DoorAction(bool open)
        {
            _animator.SetBool("Open", open);
        }
    }
}
