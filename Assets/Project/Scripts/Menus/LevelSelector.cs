using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.Menus
{
    public class LevelSelector : MonoBehaviour
    {
        [SerializeField] protected string _sala;
        public void ChangeScene()
        {
            SceneManager.LoadScene(_sala);
        }
    }
}
