using System;
using Project.Scripts.Levels._1.Logico;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1.Manten
{
    public class Button_Manten : Button_Logico
    {
        private const int PLAYER_LAYER = 6;

        private const String PULSAR_BOTON = "Press Button";
        private const String SOLTAR_BOTON = "Release Button";

        [SerializeField] private float _timeToOpenDoor;

        [SerializeField] private Door_Manten _door_Manten;

        private float _currentTime;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }

            if (!_door_Manten.IsStartOpening())
            {
                AudioManager.Instance.Play("Simple Door Sound", gameObject);
                _door_Manten.SetStartOpening(true);
            }
            
            AudioManager.Instance.Play(PULSAR_BOTON, gameObject);
            ButtonAction();
            _door_Manten.AnimatorStep(_pressed);
            _currentTime = Time.time;
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            AudioManager.Instance.Play(SOLTAR_BOTON, gameObject);
            ButtonAction();
            if (Time.time - _currentTime > _timeToOpenDoor && !_door_Manten.IsUnlocked())
            {
                _door_Manten.SetUnlock(true);
            }
            else
            {
                _door_Manten.ChangePolygonCollider(0);    
                _door_Manten.SetStartOpening(false);
            }
            _door_Manten.AnimatorStep(_pressed);
            
            _currentTime = 0;
        }
    }
}
