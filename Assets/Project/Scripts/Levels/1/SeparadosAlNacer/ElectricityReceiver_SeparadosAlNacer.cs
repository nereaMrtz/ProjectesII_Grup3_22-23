using System;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1.SeparadosAlNacer
{
    public class ElectricityReceiver_SeparadosAlNacer : MonoBehaviour
    {
        private const String BUTTON_POWER_ON = "Button Power On";
        
        [SerializeField] private ElectricityPanel_SeparadosAlNacer _electricityPanel;

        [SerializeField] private Button_SeparadosAlNacer _button;

        [SerializeField] private SpriteRenderer _spriteRenderer;

        private AudioSource _audioSource;

        private float _timeToConnect = 1;

        private void Start()
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
            AudioManager.Instance.SetAudioSourceComponent(_audioSource, BUTTON_POWER_ON);
        }

        private void OnMouseEnter()
        {
            if (_button.IsEnabled())
            {
                return;
            }
            
            if (Time.time - _electricityPanel.GetTime() > _timeToConnect)
            {
                return;
            }
            _spriteRenderer.color = new Color(1, 1, 1);
            _audioSource.Play();
            _button.EnableButton();
        }
    }
}
