using System;
using UnityEngine;

namespace Project.Scripts.Levels._1.Obrero
{
    public class Wall_Obrero : MonoBehaviour
    {
        private const int PLAYER_LAYER = 6;
        
        [SerializeField] private int _hitsToBreak;

        private void OnCollisionEnter2D(Collision2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }

            _hitsToBreak--;

            if (_hitsToBreak == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
