using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NumberLevel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI level;

    private void Start()
    {
        level.text = SceneManager.GetActiveScene().buildIndex.ToString() + ". " + level.text;
    }

}
