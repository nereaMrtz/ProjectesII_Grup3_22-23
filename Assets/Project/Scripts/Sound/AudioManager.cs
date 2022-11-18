using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Project.Scripts.Sound
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private String _musicName;
        
        [SerializeField] private Sound[] _sounds;
        [SerializeField] private AudioMixer _audioMixer;
        
        [SerializeField] private Toggle _muteToggle;
        
        private float _lastVolumeValue;

        private void Awake()
        {
            foreach (Sound sound in _sounds)
            {
                sound.SetAudioSource(gameObject.AddComponent<AudioSource>());
                sound.GetSource().clip = sound.GetClip();
                sound.GetSource().volume = sound.GetVolume();
                sound.GetSource().loop = sound.GetLoop();
                if (sound.GetPlay())
                {
                    sound.GetSource().Play();
                }
            }
        }
        
        public void SetVolume(float volume)
        {
            if (volume < -50.0f)
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

        public void UnPause(string name)
        {
            foreach (Sound sound in _sounds)
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
            foreach (Sound sound in _sounds)
            {
                if (sound.GetName() != name)
                {
                    continue;
                }
                sound.GetSource().Play();
                sound.GetSource().Pause();
            }
        }
    }
}