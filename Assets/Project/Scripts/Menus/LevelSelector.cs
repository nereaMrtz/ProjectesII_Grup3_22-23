using Project.Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Menus
{
    public class LevelSelector : MonoBehaviour
    {
        private int _levels;
        [SerializeField] Button[] button;
        
        private void Start()
        {
            _levels = GameManager.Instance.GetLevelsUnlocked();

            for(int i = 0; i < _levels; i++)
            {
                button[i].interactable = true;
            }
        }

    }
}
