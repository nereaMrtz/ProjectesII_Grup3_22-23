using Project.Scripts.Managers;
using UnityEngine;
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

            for(int i = 1; i < levels.Length; i++)
            {
                //Aqui te peta porque hay 30 elementos en "button" y este en un for de tantas iteraciones como niveles tengamos
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
