using System;
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
            
            foreach (NoMonoBehaviourClass.Sound sound in _sounds)
            {
                sound.SetAudioSource(gameObject.AddComponent<AudioSource>());
                sound.GetSource().outputAudioMixerGroup = sound.GetAudioMixerGroup();
                sound.GetSource().clip = sound.GetClip();
                sound.GetSource().volume = sound.GetVolume();
                sound.GetSource().loop = sound.GetLoop();
                if (sound.GetPlay())
                {
                    sound.GetSource().Play();
                }
            }
        }

        private void Update()
        {
            foreach (NoMonoBehaviourClass.Sound sound in _sounds)
            {
                sound.GetSource().volume = sound.GetVolume();
            }
        }

        public static AudioManager Instance
        {
            get { return _instance; }
        }

        public void Play(string name)
        {
            foreach (NoMonoBehaviourClass.Sound sound in _sounds)
            {
                if (sound.GetName() != name)
                {
                    continue;
                }
                sound.GetSource().Play();
            }
        }

        public void UnPause(string name)
        {
            foreach (NoMonoBehaviourClass.Sound sound in _sounds)
            {
                if (sound.GetName() != name)
                {
                    continue;
                }
                sound.GetSource().UnPause();
            }
        }

        public void Pause(string name)
        {
            foreach (NoMonoBehaviourClass.Sound sound in _sounds)
            {
                if (sound.GetName() != name)
                {
                    continue;
                }
                sound.GetSource().Play();
                sound.GetSource().Pause();
            }
        }

        public float ClipDuration(string name)
        {
            foreach (NoMonoBehaviourClass.Sound sound in _sounds)
            {
                if (sound.GetName() != name)
                {
                    continue;
                }

                return sound.GetClip().length;
            }

            return 0;
        }

        public void ChangePitch(bool drugged)
        {
            foreach (NoMonoBehaviourClass.Sound sound in _sounds)
            {
                sound.GetSource().pitch = drugged ? sound.GetDruggedPitch() : sound.GetSoberPitch();
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