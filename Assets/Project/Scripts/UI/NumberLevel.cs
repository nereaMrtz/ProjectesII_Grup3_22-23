using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NumberLevel : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI level;

    protected void Start()
    {
        level.text = SceneManager.GetActiveScene().buildIndex + ". " + level.text;
    }

}
