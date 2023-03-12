using Project.Scripts.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.Levels._1._1_1
{
    public class RestartLevel : MonoBehaviour
    {
        private void Start()
        {
            if (!GameManager.Instance.IsFirstLevelStarted())
            {
                GameManager.Instance.SetFirstLevelStarted();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
