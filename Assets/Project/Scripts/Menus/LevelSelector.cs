using Project.Scripts.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
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

            for(int i = 0; i < _levels && i < SceneManager.sceneCountInBuildSettings - 2; i++)
            {
                button[i].interactable = true;
            }
        }

        public void Reset()
        {
            for (int i = 1; i < button.Length; i++)
            {
                button[i].interactable = false;
            }
        }
    }
}
