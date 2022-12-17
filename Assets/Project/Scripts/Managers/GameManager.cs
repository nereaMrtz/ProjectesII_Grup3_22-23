using UnityEngine;

namespace Project.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;

        private bool _drugged;
        private bool _zoomInState; 

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
        
        public static GameManager Instance
        {
            get { return _instance; }
        }

        public void SetDrugged(bool drugged)
        {
            _drugged = drugged;
        }

        public void SetZoomInState(bool zoomInState)
        {
            _zoomInState = zoomInState;
        }

        public bool IsDrugged()
        {
            return _drugged;
        }

        public bool IsInZoomInState()
        {
            return _zoomInState;
        }
    }
}