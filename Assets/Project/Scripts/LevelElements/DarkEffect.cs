using System;
using UnityEngine;

namespace Project.Scripts.LevelElements
{
    public class DarkEffect : MonoBehaviour
    {

        private const int PLAYER_LAYER = 6;
        
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }

            _spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }

            _spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        }
    }
}
