using Project.Scripts.Character;
using Project.Scripts.Levels._1._1_1;
using UnityEngine;

namespace Project.Scripts.Levels._1.Empuja
{
    public class Door_Empuja : Door
    {
        [SerializeField] private Player _player;
        
        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.layer == 6 && _player.GetMovement().y > 0f)
            {
                _animator.SetTrigger("Open");
            }
        }
    }
}