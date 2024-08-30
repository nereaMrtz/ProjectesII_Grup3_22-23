using System.Collections;
using System.Collections.Generic;
using Project.Scripts.NoMonoBehaviourClass;
using UnityEngine;
using System;
using System.IO;

namespace Project.Scripts.Managers
{
    public class LanguageManager : MonoBehaviour
    {
        private static LanguageManager _instance;
        public LocalizationData localizationData;


        private const String SAVE_FILE_PATH = "/Languages/";

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
            LoadLocalizedText(PlayerPrefs.GetString("language", "cat"));
        }

        public static LanguageManager Instance
        {
            get { return _instance; }
        }
        public void LoadLocalizedText(string languageCode)
        {
            string filePath = Application.streamingAssetsPath + SAVE_FILE_PATH + languageCode + ".json";

            if (File.Exists(filePath))
            {
                string dataAsJson = File.ReadAllText(filePath);
                localizationData = JsonUtility.FromJson<LocalizationData>(dataAsJson);
            }
            else
            {
                Debug.LogError("Cannot find file!");
            }
        }

        public void SetLanguage(string languageCode)
        {
            PlayerPrefs.SetString("language", languageCode);
            LoadLocalizedText(languageCode);
        }

    }
}

[Serializable]
public class LocalizationData
{
    public MainMenu mainMenu;
    public Options options;
    public string back;
    public string restart;
    public string yes;
    public string no;
    public string pause;
    public string cont;
    public Level[] levels;
}

[Serializable]
public class MainMenu
{
    public string play;
    public string levels;
    public string options;
    public string credits;
    public string exit;
}

[Serializable]
public class Options
{
    public string volume;
    public string general;
    public string music;
    public string sfx;
    public string video;
    public string brightness;
    public string restart;
}

[Serializable]
public class Level
{
    public string title;
    public string hint;
    public string note;
    public string menuTitle;
    public string menuText;
}