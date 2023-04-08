using Project.Scripts.Levels._1._1_1;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.Levels._1.Ríndete
{
    public class ResetButton_Rindete : MonoBehaviour
    {
        [SerializeField] private Door _door;

        private bool _pressed;

        public void ResetButtonAction()
        {
            if (!_pressed)
            {
                _pressed = true;
                _door.Unlock();
                return;
            }

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
