using Project.Scripts.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.Menus
{
    public class MainMenu : MonoBehaviour
    {
        private const string BOTON_MENU = "BotonMenu";
        
        [SerializeField] private GameObject _actualPanel;

        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
            AudioManager.Instance.SetAudioSourceComponent(_audioSource, BOTON_MENU);
        }

        public void PlayButton()
        {
            _audioSource.Play();
            SceneManager.LoadScene(GameManager.Instance.GetLevelsUnlocked());
        }

        public void ChangePanelButton(GameObject menuToActivate)
        {
            _audioSource.Play();
            menuToActivate.SetActive(true);
            _actualPanel.SetActive(false);
            _actualPanel = menuToActivate;
        }

        public void ExitButton() {
            _audioSource.Play();
            Application.Quit();
        }
    }
}
