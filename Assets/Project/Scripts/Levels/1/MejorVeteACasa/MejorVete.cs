using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.Levels._1._1_15
{
    public class MejorVete : MonoBehaviour
    {
        private bool exitButton;

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
        {   
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
}
