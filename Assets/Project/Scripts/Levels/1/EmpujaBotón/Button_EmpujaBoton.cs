using System;
using Project.Scripts.Levels._1._1_1;
using UnityEngine;

namespace Project.Scripts.Levels._1.EmpujaBotón
{
    public class Button_EmpujaBoton : MonoBehaviour
    {
        [SerializeField] private CapsuleCollider2D _capsuleCollider2D;

        [SerializeField] private Door _door;

        private void OnCollisionEnter2D(Collision2D collision2D)
        {
            if (collision2D.gameObject != _door.gameObject)
            {
                return;
            }
            _door.Unlock();
            Destroy(_capsuleCollider2D);
            Destroy(this);
        }
    }
}
