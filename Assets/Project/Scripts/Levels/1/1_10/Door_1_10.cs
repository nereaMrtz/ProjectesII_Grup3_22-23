using Project.Scripts.Character;
using Project.Scripts.Levels._1._1_1;
using Project.Scripts.Levels._1._1._1;
using UnityEngine;

namespace Project.Scripts.Levels._1._1_10
{
    public class Door_1_10 : Door
    {
        [SerializeField] private Player _player;
        
        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.layer == 6 && _player.GetMovementY() > 0f)
            {
                _animator.SetTrigger("Open");
            }
        }
    }
}
