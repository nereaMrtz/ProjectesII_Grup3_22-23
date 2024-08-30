using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Project.Scripts.Managers;

public class LanguageMenuLevels : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelsTitleText;
    [SerializeField] TextMeshProUGUI levelsBackText;
    // Start is called before the first frame update
    void Start()
    {
        UpdateTexts();
    }

    void UpdateTexts()
    {
        levelsTitleText.text = LanguageManager.Instance.localizationData.mainMenu.levels;
    }
}
