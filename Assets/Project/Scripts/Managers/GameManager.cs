using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;

        private bool _firstLevelStarted;
        
        private bool _drugged;
        private bool _zoomInState;
        private bool _interactableClicked;
        private bool _clickOnEdge;
        private bool _pause;
        private bool _fading;

        private bool[] _levelsWhereHintUsed;
        
        private int _hintCoins = 2;

        bool[] levels = new bool[30];

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
            _levelsWhereHintUsed = new bool[SceneManager.sceneCountInBuildSettings];
        }
        
        public static GameManager Instance
        {
            get { return _instance; }
        }

        #pragma region DROGAS
        public void SetDrugged(bool drugged)
        {
            _drugged = drugged;
        }
        
        public bool IsDrugged()
        {
            return _drugged;
        }
        #pragma endregion

        public void SetZoomInState(bool zoomInState)
        {
            _zoomInState = zoomInState;
        }
        
        public bool IsInZoomInState()
        {
            return _zoomInState;
        }

        public void SetInteractableClicked(bool interactableClicked)
        {
            _interactableClicked = interactableClicked;
        }

        public bool IsInteractableClicked()
        {
            return _interactableClicked;
        }
        
        public bool IsClickingOnEdge() 
        { 
            return _clickOnEdge; 
        } 
 
        public void SetClickOnEdge(bool clickOnEdge) 
        { 
            _clickOnEdge = clickOnEdge; 
        }

        public void SetPause(bool pause)
        {
            _pause = pause;
        }

        public bool IsPause()
        {
            return _pause;
        }

        public void SetFading(bool fading) 
        { 
            _fading = fading;
        }

        public bool IsFading() 
        {
            return _fading;
        }

        public void SetHintCoins(int hintCoins)
        {
            _hintCoins = hintCoins;
        }

        public int GetHintCoins()
        {
            return _hintCoins;
        }

        public void SetHintUsedInLevel(int level)
        {
            _levelsWhereHintUsed[level] = true;
        }

        public bool IsHintUsedInLevel(int level)
        {
            return _levelsWhereHintUsed[level];
        }
        
        public void SetFirstLevelStarted()
        {
            _firstLevelStarted = true;
        }

        public bool IsFirstLevelStarted()
        {
            return _firstLevelStarted;
        }

        public bool[] GetLevels()
        {
            return levels;
        }
        public void SetLevels(int level)
        {
            levels[level] = true;
        }
    }
}