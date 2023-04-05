using System;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1.SalidaDeEmergencia
{
    public class Door_SalidaDeEmergencia : MonoBehaviour
    {
        private const String SIMPLE_DOOR_SOUND = "Simple Door Sound";

        [SerializeField] private BoxCollider2D _boxCollider2D;
        
        private AudioSource _audioSource;

        private void Start()
        {
            AudioManager.Instance.SetAudioSourceComponent(_audioSource, SIMPLE_DOOR_SOUND);
        }

        public void OpenDoor()
        {
            _audioSource.Play();
            _boxCollider2D.enabled = true;
        }
    }
}
