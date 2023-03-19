using System;
using Project.Scripts.Levels._1._1_1;
using Project.Scripts.Levels._1.Logico;
using Project.Scripts.Managers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Project.Scripts.Levels._1.SeparadosAlNacer
{
    public class Button_SeparadosAlNacer : Button_Logico
    {
        private const int PLAYER_LAYER = 6;

        private const String PULSAR_BOTON = "PulsarBoton";
        private const String SOLTAR_BOTON = "SoltarBoton";
        
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
                AudioManager.Instance.Play(PULSAR_BOTON);
                ButtonAction();
                return;
            }
            
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            
            AudioManager.Instance.Play(PULSAR_BOTON);
            ButtonAction();
            _door.Unlock();
        }
    }
}
