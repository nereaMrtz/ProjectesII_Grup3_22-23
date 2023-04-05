using System;
using Project.Scripts.Levels._1.Logico;
using Project.Scripts.Managers;
using Unity.VisualScripting;
using UnityEngine;

namespace Project.Scripts.Levels._1.Descubrelo
{
    public class Button_Descubrelo : Button_Logico
    {
        private const int PLAYER_LAYER = 6;

        private const String PULSAR_BOTON = "Press Button";
        private const String SOLTAR_BOTON = "Release Button";
        
        [SerializeField] private GameObject _flowerPotButton;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            AudioManager.Instance.Play(PULSAR_BOTON, gameObject);
            ButtonAction();
            _flowerPotButton.SetActive(true);
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            AudioManager.Instance.Play(SOLTAR_BOTON, gameObject);
            ButtonAction();
        }
    }
}
