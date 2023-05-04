using System;
using System.IO;
using Project.Scripts.NoMonoBehaviourClass;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;

        private Resolution _currentResolution;

        private bool[] _levelsWhereHintTaken;
        private bool[] _levelsWhereHintUsed;
        
        private bool _zoomInState;
        private bool _interactableClicked;
        private bool _pause;
        private bool _fading;

        private int _levelsCompleted;
        private int _coins;

        private float _brightness; 

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                if (!File.Exists(Application.streamingAssetsPath + SaveManager.SAVE_FILE_PATH))
                {
                    _levelsWhereHintTaken = new bool[SceneManager.sceneCountInBuildSettings];
                    _levelsWhereHintUsed = new bool[SceneManager.sceneCountInBuildSettings];
                    _levelsCompleted = 1;
                    _coins = 2;
                    _brightness = 1;
                    SaveFromGame();
                }
                LoadToGame();
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
            SaveManager.Instance.LoadFromJSON();
            
            SaveFile saveFile = SaveManager.Instance.GetSaveFile();

            _levelsCompleted = saveFile.levelsCompleted;
            _levelsWhereHintUsed = saveFile.levelsWhereHintUsed;
            _levelsWhereHintTaken = saveFile.levelsWhereHintTaken;
            _coins = saveFile.coins;
            _brightness = saveFile.brightness;

        }

        private void SaveFromGame()
        {
            SaveFile saveFile = SaveManager.Instance.GetSaveFile();

            saveFile.levelsCompleted = _levelsCompleted;
            saveFile.levelsWhereHintUsed = _levelsWhereHintUsed;
            saveFile.levelsWhereHintTaken = _levelsWhereHintTaken;
            saveFile.coins = _coins;
            saveFile.brightness = _brightness;
            
            SaveManager.Instance.SaveToJSON();
        }

        private void SaveLevelsFromGame()
        {
            SaveFile saveFile = SaveManager.Instance.GetSaveFile();

            saveFile.levelsCompleted = _levelsCompleted;
            
            SaveManager.Instance.SaveToJSON();
        }

        private void SaveLevelsWhereHintUsedFromGame()
        {
            SaveFile saveFile = SaveManager.Instance.GetSaveFile();

            saveFile.levelsWhereHintUsed = _levelsWhereHintUsed;
            
            SaveManager.Instance.SaveToJSON();
        }

        private void SaveLevelsWhereHintTakenFromGame()
        {
            SaveFile saveFile = SaveManager.Instance.GetSaveFile();

            saveFile.levelsWhereHintTaken = _levelsWhereHintTaken;
            
            SaveManager.Instance.SaveToJSON();
        }

        private void SaveCoinsFromGame()
        {
            SaveFile saveFile = SaveManager.Instance.GetSaveFile();

            saveFile.coins = _coins;
            
            SaveManager.Instance.SaveToJSON();
        }

        private void SaveBrightnessFromGame()
        {
            SaveFile saveFile = SaveManager.Instance.GetSaveFile();

            saveFile.brightness = _brightness;
            
            SaveManager.Instance.SaveToJSON();
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
        
        public void UnlockNextLevel()
        {
            _levelsCompleted++;
            SaveLevelsFromGame();
        }

        public int GetLevelsUnlocked()
        {
            return _levelsCompleted;
        }

        public void SetLevelWhereHintTaken(int level)
        {
            _levelsWhereHintTaken[level] = true;
            SaveLevelsWhereHintTakenFromGame();
        }

        public bool IsLevelHintTaken(int level)
        {
            return _levelsWhereHintTaken[level];
        }

        public void SetHintUsedInLevel(int level)
        {
            _levelsWhereHintUsed[level] = true;
            SaveLevelsWhereHintUsedFromGame();
        }

        public bool IsHintUsedInLevel(int level)
        {
            return _levelsWhereHintUsed[level];
        }

        public void AlterCoins(int alterValue)
        {
            _coins += alterValue;
            SaveCoinsFromGame();
        }

        public int GetHintCoins()
        {
            return _coins;
        }

        public void SetBrightness(float brightness)
        {
            _brightness = brightness;
            SaveBrightnessFromGame();
        }

        public float GetBrightness()
        {
            return _brightness;
        }

        public void ResetLevels()
        {
            _levelsWhereHintTaken = new bool[SceneManager.sceneCountInBuildSettings];
            _levelsWhereHintUsed  = new bool[SceneManager.sceneCountInBuildSettings];
            _levelsCompleted = 1;
            SaveLevelsWhereHintTakenFromGame();
            SaveLevelsWhereHintUsedFromGame();
            SaveLevelsFromGame();
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
            _levelsCompleted = SceneManager.sceneCountInBuildSettings - 1;
        }

        public void GoNextLevel()
        {
            _levelsCompleted++;
            SaveLevelsFromGame();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void GoLastLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}