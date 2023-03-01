using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] protected string _sala;
    public void ChangeScene()
    {
        SceneManager.LoadScene(_sala);
    }
}
