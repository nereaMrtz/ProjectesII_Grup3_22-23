using Project.Scripts.Character;
using UnityEngine;

namespace Project.Scripts.Levels._1._1_10
{
    public class Door_1_10 : MonoBehaviour
    {

        [SerializeField] private Animator _animator;

        [SerializeField] private Player _player;

        [SerializeField] private PolygonCollider2D[] _polygonCollider2Ds;

        private int _currentPolygonColliderIndex = 0;
        
        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.layer == 6 && _player.GetMovementY() > 0f)
            {
                _animator.SetTrigger("Open");
            }
        }

        public void ChangePolygonCollider(int index)
        {
            _polygonCollider2Ds[index].enabled = true;
            _polygonCollider2Ds[_currentPolygonColliderIndex].enabled = false;
            _currentPolygonColliderIndex = index;
        }
    }
}
