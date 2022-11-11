using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _newPanel;
    [SerializeField] private GameObject _actualPanel;
    
    private bool _isActive;

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangePanelButton()
    {
        if (_isActive == false)
        {
            _actualPanel.SetActive(false);
            _newPanel.SetActive(true);

            _isActive = true;
        }

        else
        {
            _actualPanel.SetActive(true);
            _newPanel.SetActive(false);
            
            _isActive = false;
        }
    }

    public void ExitButton() {
        Debug.Log("Exit");
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
