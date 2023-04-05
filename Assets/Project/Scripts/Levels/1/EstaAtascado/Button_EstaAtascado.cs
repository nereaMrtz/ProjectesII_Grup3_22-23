using System;
using Project.Scripts.Levels._1.Logico;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1.EstaAtascado
{
    public class Button_EstaAtascado : Button_Logico
    {

        private const String PULSAR_BOTON = "Press Button";
        private const String SOLTAR_BOTON = "Release Button";

        private int _pressCounter;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != 6)
            {
                return;
            }
            _pressCounter++;
            if (_pressCounter == 3)
            {
                _door.Unlock();
            }
            AudioManager.Instance.Play(PULSAR_BOTON, gameObject);
            ButtonAction();
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != 6)
            {
                return;
            }
            AudioManager.Instance.Play(SOLTAR_BOTON, gameObject);
            ButtonAction();
        }
    }
}
