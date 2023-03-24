using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Scripts.Managers;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameLevelSelector : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI level;
    public void ChangeScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(int.Parse(level.text));
    }
}
