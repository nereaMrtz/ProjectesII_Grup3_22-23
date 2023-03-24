using System;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1.SalidaDeEmergencia
{
    public class Button_SalidaDeEmergencia : MonoBehaviour
    {
        private const int PLAYER_LAYER = 6;

        private const String SIMPLE_DOOR_SOUND = "Simple Door Sound";

        [SerializeField] private Animator _animator;
        
        [SerializeField] private GameObject _triggerToNextLevel;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            
            _animator.SetTrigger("Press");
            AudioManager.Instance.Play(SIMPLE_DOOR_SOUND);
            _triggerToNextLevel.SetActive(true);
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            
            _animator.SetTrigger("Press");
        }
    }
}
