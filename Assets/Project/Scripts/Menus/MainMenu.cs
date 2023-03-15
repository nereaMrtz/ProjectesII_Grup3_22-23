using Project.Scripts.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.Menus
{
    public class MainMenu : MonoBehaviour
    {
        private const string BOTON_MENU = "BotonMenu";
        
        [SerializeField] private GameObject _actualPanel;

        public void PlayButton()
        {
            AudioManager.Instance.Play(BOTON_MENU);
            SceneManager.LoadScene(1);
        }

        public void ChangePanelButton(GameObject menuToActivate)
        {
            AudioManager.Instance.Play(BOTON_MENU);
            menuToActivate.SetActive(true);
            _actualPanel.SetActive(false);
            _actualPanel = menuToActivate;
        }

        public void ExitButton() {
            AudioManager.Instance.Play(BOTON_MENU);
            Application.Quit();
        }
    }
}
