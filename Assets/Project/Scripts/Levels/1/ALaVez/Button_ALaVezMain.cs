using System;
using Project.Scripts.Levels._1.Logico;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1.ALaVez
{
    public class Button_ALaVezMain : Button_Logico
    {
        private const int PLAYER_LAYER = 6;

        private const String PULSAR_BOTON = "PulsarBoton";
        private const String SOLTAR_BOTON = "SoltarBoton";

        [SerializeField] private Button_ALaVezSlave _slave;
        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            AudioManager.Instance.Play(PULSAR_BOTON);
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
            AudioManager.Instance.Play(SOLTAR_BOTON);
            ButtonAction();
        }
    }
}
