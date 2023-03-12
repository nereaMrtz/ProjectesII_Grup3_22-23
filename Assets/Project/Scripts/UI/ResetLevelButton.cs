using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.UI
{
    public class ResetLevelButton : MonoBehaviour
    {
        public void ResetLvl()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
