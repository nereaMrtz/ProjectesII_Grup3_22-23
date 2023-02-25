using System;
using Project.Scripts.Levels._1._1_1;
using Unity.VisualScripting;
using UnityEngine;

namespace Project.Scripts.Levels._1._1_14
{
    public class Button1_14Main : Button1_1
    {
        private const int PLAYER_LAYER = 6;

        [SerializeField] private Button1_14Slave _slave;
        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            ButtonAction();
            if (!_slave.IsPressed())
            {
                return;
            }
            if (_door.IsUnlocked())
            {
                return;
            }
            _door.Unlock();
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            ButtonAction();
        }
    }
}
