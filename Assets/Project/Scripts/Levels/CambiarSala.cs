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

        [SerializeField] private Fade _fade;

        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
            AudioManager.Instance.SetAudioSourceComponent(_audioSource, BOTON_MENU);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                GameManager.Instance.SetLevels(SceneManager.GetActiveScene().buildIndex);
                StartCoroutine(FadeTransition());
            }
        }

        private IEnumerator FadeTransition() {

            _fade.FadeAnimation(true);
            
            yield return new WaitUntil(() => _fade.IsFinished());

            ChangeScene();
        }

        public void SoundChangeScene()
        {
            _audioSource.Play();
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
