using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _actualPanel;

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangePanelButton(GameObject menuToActivate)
    {
        menuToActivate.SetActive(true);
        _actualPanel.SetActive(false);
        _actualPanel = menuToActivate;
    }

    public void ExitButton() {
        Debug.Log("Exit");
        Application.Quit();
    }
}
