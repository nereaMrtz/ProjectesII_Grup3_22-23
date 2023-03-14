using UnityEngine;
using UnityEngine.SceneManagement;
using Project.Scripts.Managers;
using UnityEngine.UI;

namespace Project.Scripts.Menus
{
    public class LevelSelector : MonoBehaviour
    {
        bool[] levels;
        [SerializeField] Button[] button;
       
        private void Start()
        {
            levels = GameManager.Instance.GetLevels();
            levels[0] = true;

            for(int i = 0; i < levels.Length; i++)
            {
                if (!levels[i])
                {
                    button[i].interactable = false;
                }
                else
                {
                    button[i].interactable = true;                 
                }
            }
        }
    }
}
