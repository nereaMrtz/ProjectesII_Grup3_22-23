using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.Menus
{
    public class LevelSelector : MonoBehaviour
    {
        bool[] levels = new bool[30];

        private void Start()
        {
            for(int i = 0; i < levels.Length; i++)
            {
                levels[i] = false;
            }
        }

        void UnlockLevel(int level)
        {
            levels[level] = true;
        }

    }
}
