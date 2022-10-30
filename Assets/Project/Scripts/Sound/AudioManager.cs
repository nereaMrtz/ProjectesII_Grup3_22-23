using System;
using UnityEngine.Audio;
using UnityEngine;

namespace Project.Scripts.Sound
{
    public class AudioManager : MonoBehaviour
    {

        [SerializeField] private Sound[] _sounds;

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

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}