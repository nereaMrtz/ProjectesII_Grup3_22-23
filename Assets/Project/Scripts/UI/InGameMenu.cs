using Project.Scripts.Managers;
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

        private void OnEnable()
        {
            _currentActivePanel = gameObject;
            Time.timeScale = 0;
        }
        
        private void ButtonSound()
        {
            AudioManager.Instance.PlayMenuButtonSound();
        }

        public void ResumeButton()
        {
            ButtonSound();
            GameManager.Instance.SetPause(false);
            _pauseMenuPanel.SetActive(false);
            Time.timeScale = 1;
        }

        public void ChangeMenu(GameObject menuToActivate)
        {
            ButtonSound();
            menuToActivate.SetActive(true);
            _currentActivePanel.SetActive(false);
            _currentActivePanel = menuToActivate;
        }

        public void GoToMainMenu()
        {
            ButtonSound();
            Time.timeScale = 1;
            GameManager.Instance.SetPause(false);
            SceneManager.LoadScene(MAIN_MENU_BUILD_INDEX);
        }
    }
}
