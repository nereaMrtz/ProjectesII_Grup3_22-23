using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.Menus
{
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
            Application.Quit();
        }
    }
}
