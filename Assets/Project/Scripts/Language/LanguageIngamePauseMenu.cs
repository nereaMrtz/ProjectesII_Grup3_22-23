using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Scripts.Managers;
using UnityEngine.SceneManagement;
using TMPro;

public class LanguageIngamePauseMenu : MonoBehaviour
{
    int numberLevel;
    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] TextMeshProUGUI continueText;
    [SerializeField] TextMeshProUGUI optionsText;
    [SerializeField] TextMeshProUGUI levelsText;
    [SerializeField] TextMeshProUGUI exitText;
    [SerializeField] TextMeshProUGUI menuTitleText;
    [SerializeField] TextMeshProUGUI menuExplanationText;
    // Start is called before the first frame update
    void Start()
    {
        numberLevel = SceneManager.GetActiveScene().buildIndex - 1;
        if (numberLevel == 5)
        {
            menuTitleText = GameObject.Find("ElMenu/Titulo").GetComponent<TextMeshProUGUI>();
            menuExplanationText = GameObject.Find("ElMenu/Explicacion").GetComponent<TextMeshProUGUI>();
        }

        UpdateTexts();
    }

    void UpdateTexts()
    {
        titleText.text = LanguageManager.Instance.localizationData.pause;
        continueText.text = LanguageManager.Instance.localizationData.cont;
        optionsText.text = LanguageManager.Instance.localizationData.mainMenu.options;
        levelsText.text = LanguageManager.Instance.localizationData.mainMenu.levels;
        exitText.text = LanguageManager.Instance.localizationData.mainMenu.exit;

        if (numberLevel == 5)
        {
            menuTitleText.text = LanguageManager.Instance.localizationData.levels[numberLevel].menuTitle;
            menuExplanationText.text = LanguageManager.Instance.localizationData.levels[numberLevel].menuText;
        }

    }
}
