using Project.Scripts.Levels._1._1_1;
using UnityEngine;
using UnityEngine.Serialization;

namespace Project.Scripts.Levels._1.SeparadosAlNacer
{
    public class Button_SeparadosAlNacer : Button1_1
    {
        private const int PLAYER_LAYER = 6;
        
        [SerializeField] private CursorTrailScript _cursorTrail;

        [SerializeField] private ElectricityPanel_SeparadosAlNacer _electricityPanel;

        [SerializeField] private SpriteRenderer _spriteRenderer;

        private bool _enabled;
        
        private void OnMouseEnter()
        {
            if (!_cursorTrail.GetPressed())
            {
                return;
            }
            
            if (Time.time - _electricityPanel.GetTime() > 1)
            {
                return;
            }
            
            _spriteRenderer.color = new Color(1, 1, 1);
            _enabled = true;
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (!_enabled)
            {
                ButtonAction();
                return;
            }
            
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            
            ButtonAction();
            _door.Unlock();
        }
    }
}
