using System;
using Project.Scripts.Levels._1.Logico;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1.SeparadosAlNacer
{
    public class Button_SeparadosAlNacer : Button_Logico
    {
        [SerializeField] private CursorTrailScript _cursorTrail;

        [SerializeField] private ElectricityPanel_SeparadosAlNacer _electricityPanel;

        [SerializeField] private SpriteRenderer _spriteRenderer;

        private AudioSource _audioSourcePressButton;
        private AudioSource _audioSourceReleaseButton;

        private bool _enabled;

        private void Start()
        {
            _audioSourcePressButton = gameObject.AddComponent<AudioSource>();
            _audioSourceReleaseButton = gameObject.AddComponent<AudioSource>();
            AudioManager.Instance.SetAudioSourceComponent(_audioSourcePressButton, PRESS_BUTTON);
            AudioManager.Instance.SetAudioSourceComponent(_audioSourceReleaseButton, RELEASE_BUTTON);
        }
        
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
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            _audioSourcePressButton.Play();
            ButtonAction();

            if (!_enabled)
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
            _audioSourceReleaseButton.Play();
            ButtonAction();
        }
    }
}
