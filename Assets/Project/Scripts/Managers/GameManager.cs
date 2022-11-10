using Project.Scripts.Sound;
using UnityEngine;

namespace Project.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;

        [SerializeField] private bool _drugged;

        [SerializeField] private AudioManager _audioManager;

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
        }


        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        
        public static GameManager Instance
        {
            get { return _instance; }
        }

        public void SetDrugged(bool drugged)
        {
            _drugged = drugged;
            _audioManager.ChangePitch(drugged);
        }

        public bool IsDrugged()
        {
            return _drugged;
        }

    }
}