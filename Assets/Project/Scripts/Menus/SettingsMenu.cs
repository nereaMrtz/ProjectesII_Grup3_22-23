using System;
using Project.Scripts.Managers;
using Project.Scripts.ProjectMaths;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Menus
{
    public class SettingsMenu : MonoBehaviour
    {
        private const String PLAYERS_PREFS_MASTER_VOLUME_VALUE = "Player Prefs Master Volume Value";
        private const String PLAYERS_PREFS_SFX_VOLUME_VALUE = "Player Prefs SFX Volume Value";
        private const String PLAYERS_PREFS_MUSIC_VOLUME_VALUE = "Player Prefs Music Volume Value";
        
        private const String PLAYERS_PREFS_MASTER_MUTE = "Player Prefs Master Mute";
        private const String PLAYERS_PREFS_SFX_MUTE = "Player Prefs SFX Mute";
        private const String PLAYERS_PREFS_MUSIC_MUTE = "Player Prefs Music Mute";

        [SerializeField] private Slider _masterVolumeSlider;
        [SerializeField] private Slider _SFXVolumeSlider;
        [SerializeField] private Slider _musicVolumeSlider;
        [SerializeField] private Slider _brightnessSlider;

        [SerializeField] private Toggle _masterVolumeMute;
        [SerializeField] private Toggle _SFXVolumeMute;
        [SerializeField] private Toggle _musicVolumeMute;

        [SerializeField] private Image _fadeBrightness;

        [SerializeField] private GameObject _masterMuteIcon;
        //[SerializeField] private GameObject _SFXMuteIcon;
        //[SerializeField] private GameObject _musicMuteIcon;

        private void OnEnable()
        {

            bool auxMasterVolumeMute = PlayerPrefs.GetInt(PLAYERS_PREFS_MASTER_MUTE) == 1;
            bool auxSFXVolumeMute = PlayerPrefs.GetInt(PLAYERS_PREFS_SFX_MUTE) == 1;
            bool auxMusicVolumeMute = PlayerPrefs.GetInt(PLAYERS_PREFS_MUSIC_MUTE) == 1;
            
            _masterVolumeSlider.value = PlayerPrefs.GetFloat(PLAYERS_PREFS_MASTER_VOLUME_VALUE);
            _SFXVolumeSlider.value = PlayerPrefs.GetFloat(PLAYERS_PREFS_SFX_VOLUME_VALUE);
            _musicVolumeSlider.value = PlayerPrefs.GetFloat(PLAYERS_PREFS_MUSIC_VOLUME_VALUE);

            _masterVolumeMute.isOn = auxMasterVolumeMute;
            _SFXVolumeMute.isOn = auxSFXVolumeMute;
            _musicVolumeMute.isOn = auxMusicVolumeMute;

            _brightnessSlider.value = GameManager.Instance.GetBrightness();
        }

        public void SetBrightness(float brightness)
        {
            float auxAlpha = CustomMath.Map(brightness, 0, 1, 0.85f, 0);
            _fadeBrightness.color = new Color(0, 0, 0, auxAlpha);
            GameManager.Instance.SetBrightness(brightness);
        }

        public void SetMasterVolume(float volume)
        {
            SetVolume(volume, PLAYERS_PREFS_MASTER_VOLUME_VALUE, PLAYERS_PREFS_MASTER_MUTE);
        }
        
        public void SetSFXVolume(float volume)
        {
            SetVolume(volume, PLAYERS_PREFS_SFX_VOLUME_VALUE, PLAYERS_PREFS_SFX_MUTE);
        }
        
        public void SetMusicVolume(float volume)
        {
            SetVolume(volume, PLAYERS_PREFS_MUSIC_VOLUME_VALUE, PLAYERS_PREFS_MUSIC_MUTE);
        }

        public void SetVolume(float volume, String playerPrefsVolumeMixer, String playerPrefsMute/*, GameObject iconMute*/)
        {
            if (volume <= -30.0f)
            {
                AudioManager.Instance.SetVolumePrefs(playerPrefsVolumeMixer, -80);
                SetMuteToggle(true, playerPrefsVolumeMixer);
                PlayerPrefs.SetInt(playerPrefsMute, 1);
                if (playerPrefsVolumeMixer != PLAYERS_PREFS_MASTER_VOLUME_VALUE)
                {
                    return;
                }
                _masterMuteIcon.SetActive(true);
                //iconMute.SetActive(true);
            }
            else
            {
                AudioManager.Instance.SetVolumePrefs(playerPrefsVolumeMixer, volume);
                SetMuteToggle(false, playerPrefsVolumeMixer);
                PlayerPrefs.SetInt(playerPrefsMute, 0);
                if (playerPrefsVolumeMixer != PLAYERS_PREFS_MASTER_VOLUME_VALUE)
                {
                    return;
                }
                _masterMuteIcon.SetActive(false);
                //iconMute.SetActive(false);
            }
        }

        private void SetMuteToggle(bool mute, String playerPrefsVolumeMixer)
        {
            switch (playerPrefsVolumeMixer)
            {
                case PLAYERS_PREFS_MASTER_VOLUME_VALUE:
                    _masterVolumeMute.isOn = mute;
                    break;
                case PLAYERS_PREFS_SFX_VOLUME_VALUE:
                    _SFXVolumeMute.isOn = mute;
                    break;
                default:
                    _musicVolumeMute.isOn = mute;
                    break;
            }
        }

        public void MuteMaster(bool mute)
        {
            Mute(mute, PLAYERS_PREFS_MASTER_VOLUME_VALUE, PLAYERS_PREFS_MASTER_MUTE/*, _masterMuteIcon*/);
        }

        public void MuteSFX(bool mute)
        {
            Mute(mute, PLAYERS_PREFS_SFX_VOLUME_VALUE, PLAYERS_PREFS_SFX_MUTE/*, _SFXMuteIcon*/);
        }

        public void MuteMusic(bool mute)
        {
            Mute(mute, PLAYERS_PREFS_MUSIC_VOLUME_VALUE, PLAYERS_PREFS_MUSIC_MUTE/*, _musicMuteIcon*/);
        }

        public void Mute(bool mute, String playerPrefsVolumeMixer, String playerPrefsMute/*, GameObject iconMute*/)
        {
            if (mute)
            {
                AudioManager.Instance.SetVolumePrefs(playerPrefsVolumeMixer, PlayerPrefs.GetFloat(playerPrefsVolumeMixer));
                AudioManager.Instance.SetVolumeValue(playerPrefsVolumeMixer, -80);
                PlayerPrefs.SetInt(playerPrefsMute, 1);
                if (playerPrefsVolumeMixer != PLAYERS_PREFS_MASTER_VOLUME_VALUE)
                {
                    return;
                }
                _masterMuteIcon.SetActive(true);
                //iconMute.SetActive(true);
            }
            else
            {
                AudioManager.Instance.SetVolumePrefs(playerPrefsVolumeMixer, PlayerPrefs.GetFloat(playerPrefsVolumeMixer));
                PlayerPrefs.SetInt(playerPrefsMute, 0);
                if (playerPrefsVolumeMixer != PLAYERS_PREFS_MASTER_VOLUME_VALUE)
                {
                    return;
                }
                _masterMuteIcon.SetActive(false);
                //iconMute.SetActive(false);
            }
        }
    }
}
