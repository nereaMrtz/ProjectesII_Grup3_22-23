using UnityEngine;

namespace Project.Scripts.Managers
{
    public class AudioManager : MonoBehaviour
    {

        private static AudioManager _instance;
        
        [SerializeField] private NoMonoBehaviourClass.Sound[] _sounds;
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
            
            foreach (NoMonoBehaviourClass.Sound sound in _sounds)
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
        
        public static AudioManager Instance
        {
            get { return _instance; }
        }

        private void Update()
        {
            if (GameManager.Instance.IsDrugged())
            {
                ChangePitch(true);
            }
            else
            {
                ChangePitch(false);
            }
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
    }
}