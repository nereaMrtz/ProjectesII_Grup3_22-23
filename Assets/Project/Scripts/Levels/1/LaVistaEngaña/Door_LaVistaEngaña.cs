using Project.Scripts.Levels._1._1_1;
using Project.Scripts.Managers;

namespace Project.Scripts.Levels._1.LaVistaEngaña
{
    public class Door_LaVistaEngaña : Door
    {
        public override void Unlock()
        {
            _audioSource.Play();
            _unlocked = true;
            ChangePolygonCollider(4);
        }
    }
}
