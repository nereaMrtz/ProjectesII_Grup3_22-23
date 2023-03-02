using System;
using Project.Scripts.Levels._1._1_1;
using Project.Scripts.Levels._1._1_1;
using UnityEngine;

namespace Project.Scripts.Levels._1._1_8
{
    public class Flowerpot_1_8 : MonoBehaviour
    {
        [SerializeField] private Door _door;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == 6)
            {
                _door.Unlock();    
            }
        }
    }
}
