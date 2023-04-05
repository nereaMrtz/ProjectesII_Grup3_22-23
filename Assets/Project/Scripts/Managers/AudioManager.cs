using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

namespace Project.Scripts.Managers
{
    public class AudioManager : MonoBehaviour
    {
        private static AudioManager _instance;
        
        private const String PLAYERS_PREFS_MASTER_VOLUME_VALUE = "Player Prefs Master Volume Value";
        private const String PLAYERS_PREFS_SFX_VOLUME_VALUE = "Player Prefs SFX Volume Value";
        private const String PLAYERS_PREFS_MUSIC_VOLUME_VALUE = "Player Prefs Music Volume Value";

        [SerializeField] private AudioMixer _audioMixer;
        
        [SerializeField] private String _masterVolumeMixer;
        [SerializeField] private String _SFXVolumeMixer;
        [SerializeField] private String _musicVolumeMixer;
        
        [SerializeField] private NoMonoBehaviourClass.Sound[] _sounds;

        private AudioSource _audioSource;
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            
                PlayerPrefs.SetFloat(PLAYERS_PREFS_MASTER_VOLUME_VALUE, -8);
                PlayerPrefs.SetFloat(PLAYERS_PREFS_SFX_VOLUME_VALUE, -8);
                PlayerPrefs.SetFloat(PLAYERS_PREFS_MUSIC_VOLUME_VALUE, -8);
            }
            else
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);

            _audioSource = gameObject.AddComponent<AudioSource>();
            SetAudioSourceComponent(_audioSource, "Ambiente");

        }

        public static AudioManager Instance
        {
            get { return _instance; }
        }
        
        public void SetAudioSourceComponent(AudioSource audioSource, string name)
        {
            foreach (NoMonoBehaviourClass.Sound sound in _sounds)
            {
                if (sound.GetName() != name)
                {
                    continue;
                }
                sound.SetAudioSource(audioSource);
                sound.GetAudioSource().outputAudioMixerGroup = sound.GetAudioMixerGroup();
                sound.GetAudioSource().clip = sound.GetClip();
                sound.GetAudioSource().volume = sound.GetVolume();
                sound.GetAudioSource().loop = sound.GetLoop();
                sound.GetAudioSource().spatialBlend = Convert.ToSingle(sound.GetSound3D());
                if (sound.GetSound3D())
                {
                    sound.GetAudioSource().rolloffMode = AudioRolloffMode.Linear;
                    sound.GetAudioSource().minDistance = 0;
                    sound.GetAudioSource().maxDistance = 30;    
                }

                if (sound.GetPlay())
                {
                    sound.GetAudioSource().Play();
                }

                return;
            }
        }

        public void SetVolumePrefs(String playerPrefsVolumeName, float volumeValue)
        {
            PlayerPrefs.SetFloat(playerPrefsVolumeName, volumeValue);
            SetVolumeValue(playerPrefsVolumeName, volumeValue);
        }

        public void SetVolumeValue(String playerPrefsVolumeName, float volumeValue)
        {
            switch (playerPrefsVolumeName)
            {
                case PLAYERS_PREFS_MASTER_VOLUME_VALUE:
                    _audioMixer.SetFloat(_masterVolumeMixer, volumeValue);
                    break;
                case PLAYERS_PREFS_SFX_VOLUME_VALUE:
                    _audioMixer.SetFloat(_SFXVolumeMixer, volumeValue);
                    break;
                default:
                    _audioMixer.SetFloat(_musicVolumeMixer, volumeValue);
                    break;
            }
        }
    }
}