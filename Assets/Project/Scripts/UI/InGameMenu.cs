using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.UI
{
    public class InGameMenu : MonoBehaviour
    {
        private const int MAIN_MENU_BUILD_INDEX = 0;

        [SerializeField] private GameObject _pauseMenuPanel;

        private GameObject _currentActivePanel;

        private bool _active;

        private void Start()
        {
            _currentActivePanel = gameObject;
            _pauseMenuPanel.SetActive(false);
        }

        public void ResumeButton()
        {
            _pauseMenuPanel.SetActive(false);
            Time.timeScale = 1;
        }

        public void ChangeMenu(GameObject menuToActivate)
        {
            menuToActivate.SetActive(true);
            _currentActivePanel.SetActive(false);
            _currentActivePanel = menuToActivate;
        }

        public void GoToMainMenu()
        {
            SceneManager.LoadScene(MAIN_MENU_BUILD_INDEX);
        }
    }
}
