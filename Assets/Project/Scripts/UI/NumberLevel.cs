using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumberLevel : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI level;

    private void Start()
    {
        level.text = SceneManager.GetActiveScene().buildIndex.ToString() + ". " + level.text;
    }

}
