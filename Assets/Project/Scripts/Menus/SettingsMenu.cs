using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Project.Scripts.Menus
{
    public class SettingsMenu : MonoBehaviour
    {
        private const String PLAYERS_PREFS_MUTE = "Player Prefs Mute";

        private const String SETTINGS_MENU_NAME = "Settings Menu";
        
        [SerializeField] private String _masterVolumeMixer;
        [SerializeField] private String _SFXVolumeMixer;
        [SerializeField] private String _musicVolumeMixer;

        [SerializeField] private Slider _masterVolumeSlider;
        [SerializeField] private Slider _SFXVolumeSlider;
        [SerializeField] private Slider _musicVolumeSlider;

        [SerializeField] private Toggle _masterVolumeMute;
        [SerializeField] private Toggle _SFXVolumeMute;
        [SerializeField] private Toggle _musicVolumeMute;

        [SerializeField] private AudioMixer _audioMixer;

        [SerializeField] private GameObject _muteIcon;
    
        [SerializeField] private float _lastMasterVolumeValue;
        [SerializeField] private float _lastSFXVolumeValue;
        [SerializeField] private float _lastMusicVolumeValue;

        private void OnEnable()
        {
            _audioMixer.GetFloat(_masterVolumeMixer, out var masterVolumeValue);
            _audioMixer.GetFloat(_SFXVolumeMixer, out var SFXVolumeValue);
            _audioMixer.GetFloat(_musicVolumeMixer, out var musicVolumeValue);

            _masterVolumeSlider.value = masterVolumeValue;
            _SFXVolumeSlider.value = SFXVolumeValue;
            _musicVolumeSlider.value = musicVolumeValue;
        }

        public void FullScreenToggle(bool fullScreen)
        {
            Screen.fullScreen = fullScreen;
        }

        public void SetMasterVolume(float volume)
        {
            SetVolume(volume, _masterVolumeMixer, _lastMasterVolumeValue);
        }
        
        public void SetSFXVolume(float volume)
        {
            SetVolume(volume, _SFXVolumeMixer, _lastSFXVolumeValue);
        }
        
        public void SetMusicVolume(float volume)
        {
            SetVolume(volume, _musicVolumeMixer, _lastMusicVolumeValue);
        }

        public void SetVolume(float volume, String volumeMixer, float _lastVolumeValue)
        {
            if (volume <= -50.0f)
            {
                _audioMixer.SetFloat(volumeMixer, -80);
                if (volumeMixer == _masterVolumeMixer)
                {
                    SetMuteToggle(true, volumeMixer);
                    PlayerPrefs.SetInt(PLAYERS_PREFS_MUTE, 1);
                    _muteIcon.SetActive(true);
                }
            }
            else
            {
                _audioMixer.SetFloat(volumeMixer, volume);
                if (volumeMixer == _masterVolumeMixer)
                {
                    SetMuteToggle(false, volumeMixer);
                    PlayerPrefs.SetInt(PLAYERS_PREFS_MUTE, 0);
                    _muteIcon.SetActive(false);
                }
            }
            SetLastVolumeValue(volume, volumeMixer);
        }

        private void SetMuteToggle(bool mute, String volumeMixer)
        {
            if (volumeMixer == _masterVolumeMixer)
            {
                _masterVolumeMute.isOn = mute;
            }
            else if (volumeMixer == _SFXVolumeMixer)
            {
                _SFXVolumeMute.isOn = mute;
            }
            else
            {
                _musicVolumeMute.isOn = mute;
            }
        }

        private void SetLastVolumeValue(float lastVolumeValue, String volumeMixer)
        {
            if (volumeMixer == _masterVolumeMixer)
            {
                _lastMasterVolumeValue = lastVolumeValue;
            }
            else if (volumeMixer == _SFXVolumeMixer)
            {
                _lastSFXVolumeValue = lastVolumeValue;
            }
            else
            {
                _lastMusicVolumeValue = lastVolumeValue;
            }
        }

        public void MuteMaster(bool mute)
        {
            Mute(mute, _masterVolumeMixer, _lastMasterVolumeValue);
        }

        public void MuteSFX(bool mute)
        {
            Mute(mute, _SFXVolumeMixer, _lastSFXVolumeValue);
        }

        public void MuteMusic(bool mute)
        {
            Mute(mute, _musicVolumeMixer, _lastMusicVolumeValue);
        }

        public void Mute(bool mute, String volumeMixer, float _lastVolumeValue)
        {
            if (mute)
            {
                _audioMixer.SetFloat(volumeMixer, -80);
                if (volumeMixer == _masterVolumeMixer)
                {
                    _muteIcon.SetActive(true);
                }
            }
            else
            {
                _audioMixer.SetFloat(volumeMixer, _lastVolumeValue);
                if (volumeMixer == _masterVolumeMixer)
                {
                    _muteIcon.SetActive(false);
                }
            }
        }
    }
}
