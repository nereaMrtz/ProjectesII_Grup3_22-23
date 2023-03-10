using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rindete : MonoBehaviour
{
    bool exitButton = false;

    [SerializeField] GameObject openPopup;
    [SerializeField] GameObject openDoor;
    [SerializeField] GameObject pauseMenu;

    public void DestroyPopup()
    {
        Destroy(gameObject);
    }

    public void EnableExitButton()
    {
        exitButton = true;
    }

    public void ExitButton()

    {   Debug.Log("pulsao");
        if (!exitButton)
        {
            openPopup.SetActive(true);
            pauseMenu.SetActive(false);
        }
        else
        {
            pauseMenu.SetActive(true);
            SceneManager.LoadScene("MainMenu");
        }    
    }

}
