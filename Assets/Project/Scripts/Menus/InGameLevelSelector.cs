using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameLevelSelector : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI level;
    public void ChangeScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(int.Parse(level.text));
    }
}
