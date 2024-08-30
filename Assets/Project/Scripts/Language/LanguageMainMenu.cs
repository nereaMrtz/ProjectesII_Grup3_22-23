using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Project.Scripts.Managers;

public class LanguageMainMenu : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI playText;
    [SerializeField] TextMeshProUGUI levelsText;
    [SerializeField] TextMeshProUGUI optionsText;
    [SerializeField] TextMeshProUGUI creditsText;
    [SerializeField] TextMeshProUGUI quitText;
    [SerializeField] TextMeshProUGUI optionsTitleText;
    [SerializeField] TextMeshProUGUI volumeText;
    [SerializeField] TextMeshProUGUI videoText;
    [SerializeField] TextMeshProUGUI masterVolumeText;
    [SerializeField] TextMeshProUGUI musicVolumeText;
    [SerializeField] TextMeshProUGUI sfxVolumeText;
    [SerializeField] TextMeshProUGUI brightnessText;
    [SerializeField] TextMeshProUGUI restartText;
    [SerializeField] TextMeshProUGUI backText;
    [SerializeField] TextMeshProUGUI creditsTitleText;
    [SerializeField] TextMeshProUGUI creditsBackText;
    [SerializeField] TextMeshProUGUI levelsTitleText;
    [SerializeField] TextMeshProUGUI levelsBackText;
    [SerializeField] TextMeshProUGUI resetText;
    [SerializeField] TextMeshProUGUI resetYesText;
    [SerializeField] TextMeshProUGUI resetNoText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateTexts();
    }

    public void SwitchLanguage(string languageCode)
    {
        LanguageManager.Instance.SetLanguage(languageCode);
        UpdateTexts();
    }

    void UpdateTexts()
    {
        playText.text = LanguageManager.Instance.localizationData.mainMenu.play;
        levelsText.text = LanguageManager.Instance.localizationData.mainMenu.levels;
        optionsText.text = LanguageManager.Instance.localizationData.mainMenu.options;
        creditsText.text = LanguageManager.Instance.localizationData.mainMenu.credits;
        quitText.text = LanguageManager.Instance.localizationData.mainMenu.exit;

        optionsTitleText.text = LanguageManager.Instance.localizationData.mainMenu.options;
        volumeText.text = LanguageManager.Instance.localizationData.options.volume;
        videoText.text = LanguageManager.Instance.localizationData.options.video;
        masterVolumeText.text = LanguageManager.Instance.localizationData.options.general;
        musicVolumeText.text = LanguageManager.Instance.localizationData.options.music;
        sfxVolumeText.text = LanguageManager.Instance.localizationData.options.sfx;
        brightnessText.text = LanguageManager.Instance.localizationData.options.brightness;
        restartText.text = LanguageManager.Instance.localizationData.options.restart;
        backText.text = LanguageManager.Instance.localizationData.back;

        creditsTitleText.text = LanguageManager.Instance.localizationData.mainMenu.credits;
        creditsBackText.text = LanguageManager.Instance.localizationData.back;

        levelsTitleText.text = LanguageManager.Instance.localizationData.mainMenu.levels;
        levelsBackText.text = LanguageManager.Instance.localizationData.back;

        resetText.text = LanguageManager.Instance.localizationData.restart;
        resetYesText.text = LanguageManager.Instance.localizationData.yes;
        resetNoText.text = LanguageManager.Instance.localizationData.no;

    }
}
