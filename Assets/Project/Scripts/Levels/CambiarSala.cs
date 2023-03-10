using Project.Scripts.UI;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.Levels
{
    public class CambiarSala : MonoBehaviour
    {
        [SerializeField] protected string _sala;

        [SerializeField] private Fade _fade;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                StartCoroutine(FadeTransition());
            }
        }

        public IEnumerator FadeTransition() {

            _fade.FadeAnimation();

            yield return new WaitUntil(() => _fade.IsFinished());

            ChangeScene();
        }

        private void ChangeScene()
        {
            SceneManager.LoadScene(_sala);
        }
    }
}
