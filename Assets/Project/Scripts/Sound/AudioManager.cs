using System;
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
            }
        }

        public void Play(string name)
        {
            Sound sound = Array.Find(_sounds, sound => sound.GetName() == name);
            if (sound != null)
            {
                return;
            }
            sound.GetSource().Play();
        }

        public void Stop(string name)
        {
            Sound sound = Array.Find(_sounds, sound => sound.GetName() == name);
            if (sound != null)
            {
                return;
            }
            sound.GetSource().Stop();
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}