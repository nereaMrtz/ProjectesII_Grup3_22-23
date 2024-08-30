using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Project.Scripts.Managers;

public class LanguageOptions : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI optionsTitleText;
    [SerializeField] TextMeshProUGUI volumeText;
    [SerializeField] TextMeshProUGUI videoText;
    [SerializeField] TextMeshProUGUI masterVolumeText;
    [SerializeField] TextMeshProUGUI musicVolumeText;
    [SerializeField] TextMeshProUGUI sfxVolumeText;
    [SerializeField] TextMeshProUGUI brightnessText;
    [SerializeField] TextMeshProUGUI backText;
    // Start is called before the first frame update
    void Start()
    {
        UpdateTexts();
    }

    void UpdateTexts()
    {
        optionsTitleText.text = LanguageManager.Instance.localizationData.mainMenu.options;
        volumeText.text = LanguageManager.Instance.localizationData.options.volume;
        videoText.text = LanguageManager.Instance.localizationData.options.video;
        masterVolumeText.text = LanguageManager.Instance.localizationData.options.general;
        musicVolumeText.text = LanguageManager.Instance.localizationData.options.music;
        sfxVolumeText.text = LanguageManager.Instance.localizationData.options.sfx;
        brightnessText.text = LanguageManager.Instance.localizationData.options.brightness;
        backText.text = LanguageManager.Instance.localizationData.back;
    }
}
