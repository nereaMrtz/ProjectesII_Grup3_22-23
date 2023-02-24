using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Project.Scripts.Menus
{
    public class SettingsMenu : MonoBehaviour
    {
        private const String SETTINGS_MENU_NAME = "Settings Menu";
        
        [SerializeField] private String _musicName;
        [SerializeField] private Slider _slider;
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private Toggle _muteToggle;
    
        private float _lastVolumeValue;

        private void OnEnable()
        {
            _audioMixer.GetFloat(_musicName, out var volumeValue);
            _slider.value = volumeValue;
        }

        public void FullScreenToggle(bool fullScreen)
        {
            Screen.fullScreen = fullScreen;
        }
        
        public void SetVolume(float volume)
        {
            if (volume <= -50.0f)
            {
                _audioMixer.SetFloat(_musicName, -80);
                _muteToggle.isOn = true;
            }
            else
            {
                _audioMixer.SetFloat(_musicName, volume);
                _muteToggle.isOn = false;
            }
            _lastVolumeValue = volume;
            
        }
    
        public void Mute(bool mute)
        {
            if (mute)
            {
                _audioMixer.SetFloat(_musicName, -80);
            }
            else
            {
                _audioMixer.SetFloat(_musicName, _lastVolumeValue);
            }
        }
        
    }
}
