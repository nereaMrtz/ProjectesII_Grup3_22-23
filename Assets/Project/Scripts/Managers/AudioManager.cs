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
            
            Play("Ambiente", gameObject);
            Play("Steps Sound", gameObject);
        }

        public static AudioManager Instance
        {
            get { return _instance; }
        }

        public void Play(string name, GameObject gameObjectToPlaySound)
        {
            foreach (NoMonoBehaviourClass.Sound sound in _sounds)
            {
                if (sound.GetName() != name)
                {
                    continue;
                }

                AudioSource audioSource = gameObjectToPlaySound.AddComponent<AudioSource>(); 
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
                    sound.GetAudioSource().maxDistance = sound.GetSoundMaxDistance();    
                }
                sound.GetAudioSource().Play();
                if (sound.GetLoop())
                {
                    return;
                }
                StartCoroutine(DestroyAudioSource(audioSource, ClipDuration(sound.GetName())));
                return;
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
                sound.GetAudioSource().UnPause();
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
                sound.GetAudioSource().Play();
                sound.GetAudioSource().Pause();
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

        private IEnumerator DestroyAudioSource(AudioSource audioSource, float clipDuration)
        {
            yield return new WaitForSecondsRealtime(clipDuration);
            Destroy(audioSource);
        }
    }
}