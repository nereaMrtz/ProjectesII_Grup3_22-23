using System.Collections;
using Project.Scripts.Managers;
using Project.Scripts.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.Levels
{
    public class CambiarSala : MonoBehaviour
    {
        private const string BOTON_MENU = "BotonMenu";
        private const string FADE = "Fade";

        [SerializeField] private Fade _fade;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                GameManager.Instance.SetLevels(SceneManager.GetActiveScene().buildIndex - 1);
                StartCoroutine(FadeTransition());
            }
        }

        private IEnumerator FadeTransition() {

            _fade.FadeAnimation();
            
            AudioManager.Instance.Play(FADE, gameObject);
            
            yield return new WaitUntil(() => _fade.IsFinished());

            ChangeScene();
        }

        public void SoundChangeScene()
        {
            AudioManager.Instance.Play(BOTON_MENU, gameObject);
        }

        public void ChangeScene()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
