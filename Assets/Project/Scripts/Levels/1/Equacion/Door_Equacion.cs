using Project.Scripts.Levels._1._1_1;

namespace Project.Scripts.Levels._1.Equacion
{
    public class Door_Equacion : Door
    {
        public void OpenDoor()
        {
            _animator.SetBool("Open", true);
        }

        public void CloseDoor()
        {
            _animator.SetBool("Open", false);
        }
    }
}
