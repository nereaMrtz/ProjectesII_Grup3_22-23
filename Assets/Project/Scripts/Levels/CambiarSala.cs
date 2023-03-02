using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.Levels
{
    public class CambiarSala : MonoBehaviour
    {
        [SerializeField] protected string _sala;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                ChangeScene();   
            }
        }

        public void ChangeScene()
        {
            SceneManager.LoadScene(_sala);
        }
    }
}
