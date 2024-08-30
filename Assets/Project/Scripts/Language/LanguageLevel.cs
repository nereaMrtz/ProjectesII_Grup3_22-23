using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Scripts.Managers;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;

public class LanguageLevel : MonoBehaviour
{
    int numberLevel;
    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] TextMeshProUGUI hintText;
    [SerializeField] TextMeshProUGUI noteText;
    public TextMeshProUGUI[] allGameObjects;

    List<int> levelsWithNote = new List<int> { 29, 43 };

    void Start()
    {
        numberLevel = SceneManager.GetActiveScene().buildIndex - 1;
        UpdateTexts();
        if (levelsWithNote.Contains(numberLevel + 1))
        {
            GameObject note = GameObject.Find("Nota");
            noteText = GameObject.Find("/Nota/Image/text").GetComponent<TextMeshProUGUI>();
            noteText.text = LanguageManager.Instance.localizationData.levels[numberLevel].note;
            note.SetActive(false);
        }
    }

    void UpdateTexts()
    {
        titleText.text = GetLevelTitle(numberLevel);
        hintText.text = GetLevelHint(numberLevel);
    }

    string GetLevelTitle(int levelKey)
    {
        return LanguageManager.Instance.localizationData.levels[numberLevel].title;
    }

    string GetLevelHint(int levelKey)
    {
        return LanguageManager.Instance.localizationData.levels[numberLevel].hint;
    }

}
