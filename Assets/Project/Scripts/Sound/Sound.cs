using UnityEngine;


namespace Project.Scripts.Sound
{
    [System.Serializable]
    public class Sound
    {
        private AudioSource _source;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private string _name;
    
        [Range(0, 1)]
        [SerializeField] private float _volume;
        [SerializeField] private bool _loop;
        [SerializeField] private bool _play;

        public AudioSource GetSource()
        {
            return _source;
        }

        public void SetAudioSource(AudioSource source)
        {
            _source = source;
        }

        public AudioClip GetClip()
        {
            return _audioClip;
        }

        public void SetAudioClip(AudioClip audioClip)
        {
            _audioClip = audioClip;
        }

        public float GetVolume()
        {
            return _volume;
        }

        public void SetVolume(float volume)
        {
            _volume = volume;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public bool GetLoop()
        {
            return _loop;
        }

        public void SetLoop(bool loop)
        {
            _loop = loop;
        }

        public bool GetPlay()
        {
            return _play;
        }

        public void SetPLay(bool play)
        {
            _play = play;
        }
    }
}


