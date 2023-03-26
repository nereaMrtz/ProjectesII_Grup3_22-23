using System;
using Project.Scripts.Levels._1._1_1;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1.LaVistaEngaña
{
    public class Button_LaVistaEngaña : MonoBehaviour
    {
        private const int PLAYER_LAYER = 6;
        
        [SerializeField] private Door_LaVistaEngaña _door;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }

            if (!_door.IsUnlocked())
            {
                _door.Unlock();
            }
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            
            //AudioManager.Instance.Play();
        }
    }
}
