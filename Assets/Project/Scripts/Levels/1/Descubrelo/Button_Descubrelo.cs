using System;
using Project.Scripts.Levels._1.Logico;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1.Descubrelo
{
    public class Button_Descubrelo : Button_Logico
    {
        private const String DISCOVERY = "Discovery";
        
        [SerializeField] private GameObject _flowerPotButton;

        private AudioSource _audioSourceDiscovery;

        private new void Start()
        {
            base.Start();
            _audioSourceDiscovery = _flowerPotButton.AddComponent<AudioSource>();
            AudioManager.Instance.SetAudioSourceComponent(_audioSourceDiscovery, DISCOVERY);
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            _audioSourcePressButton.Play();
            ButtonAction();

            if (!_flowerPotButton.activeSelf)
            {
                _flowerPotButton.SetActive(true);
                _audioSourceDiscovery.Play();
            }
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            _audioSourceReleaseButton.Play();
            ButtonAction();
        }
    }
}
