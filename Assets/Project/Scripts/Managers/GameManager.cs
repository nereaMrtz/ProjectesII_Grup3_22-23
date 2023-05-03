using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        
        private const String PLAYER_PREFS_BRIGHTNESS = "Player Prefs Brightness";
        private const String PLAYER_PREFS_COINS = "Player Prefs Coins";

        private Resolution _currentResolution;
        
        private bool _drugged;
        private bool _zoomInState;
        private bool _interactableClicked;
        private bool _pause;
        private bool _fading;

        private bool[] _levelsWhereHintTaken;
        private bool[] _levelsWhereHintUsed;

        private bool[] levels;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                _levelsWhereHintTaken = new bool[SceneManager.sceneCountInBuildSettings];
                _levelsWhereHintUsed = new bool[SceneManager.sceneCountInBuildSettings];
                levels = new bool[SceneManager.sceneCountInBuildSettings - 1];
                levels[0] = true;
                if (!PlayerPrefs.HasKey(PLAYER_PREFS_BRIGHTNESS))
                {
                    PlayerPrefs.SetFloat(PLAYER_PREFS_BRIGHTNESS, 1);
                }

                if (!PlayerPrefs.HasKey(PLAYER_PREFS_COINS))
                {
                    PlayerPrefs.SetInt(PLAYER_PREFS_COINS, 2);
                }
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

        public void LoadToGame()
        {
            
        }

        public void SaveFromGame()
        {
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
            PlayerPrefs.SetInt(PLAYER_PREFS_COINS, hintCoins);
        }

        public int GetHintCoins()
        {
            return PlayerPrefs.GetInt(PLAYER_PREFS_COINS);
        }

        public void SetLevelWhereHintTaken(int level)
        {
            _levelsWhereHintTaken[level] = true;
        }

        public bool IsLevelHintTaken(int level)
        {
            return _levelsWhereHintTaken[level];
        }

        public void SetHintUsedInLevel(int level)
        {
            _levelsWhereHintUsed[level] = true;
        }

        public bool IsHintUsedInLevel(int level)
        {
            return _levelsWhereHintUsed[level];
        }

        public bool[] GetLevels()
        {
            return levels;
        }
        
        public void SetLevels(int level)
        {
            levels[level] = true;
        }
        
        public void ResetLevels()
        {
            _levelsWhereHintTaken = new bool[SceneManager.sceneCountInBuildSettings];
            _levelsWhereHintUsed  = new bool[SceneManager.sceneCountInBuildSettings];
            levels = new bool[SceneManager.sceneCountInBuildSettings];
        }

        public void SetCurrentResolution(Resolution resolution)
        {
            _currentResolution = resolution;
        }

        public void ApplyResolution()
        {
            Screen.SetResolution(_currentResolution.width, _currentResolution.height, true);
        }

        public void UnlockAllLevels()
        {
            for (int i = 0; i < levels.Length; i++)
            {
                levels[i] = true;
            }
        }

        public void GoNextLevel()
        {
            levels[SceneManager.GetActiveScene().buildIndex] = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void GoLastLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        public void AddCoin()
        {
            PlayerPrefs.SetInt(PLAYER_PREFS_COINS, PlayerPrefs.GetInt(PLAYER_PREFS_COINS) + 1);
        }
    }
}