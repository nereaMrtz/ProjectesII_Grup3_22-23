using System.Collections;
using Project.Scripts.Managers;
using Project.Scripts.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.Levels
{
    public class CambiarSala : MonoBehaviour
    {
        [SerializeField] private Fade _fade;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                GameManager.Instance.SetLevels(SceneManager.GetActiveScene().buildIndex);
                SaveManager.Instance.SaveToJSON();
                StartCoroutine(FadeTransition());
            }
        }

        public IEnumerator FadeTransition() {

            _fade.FadeAnimation(true);
            
            yield return new WaitUntil(() => _fade.IsFinished());

            ChangeScene();
        }

        public void SoundChangeScene()
        {
            AudioManager.Instance.PlayMenuButtonSound();
        }

        public void ChangeScene()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void GoToMainMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}