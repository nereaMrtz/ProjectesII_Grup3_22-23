using System;
using Project.Scripts.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Project.Scripts.UI
{
    public class HintButton : MonoBehaviour
    {
        private const String EXCLUDE_LEVEL = "MeSobraElDinero";
        
        [SerializeField] private Button _button;

        private void OnEnable()
        {
            if (GameManager.Instance.GetHintCoins() == 0 && SceneManager.GetActiveScene().name != EXCLUDE_LEVEL)
            {
                _button.interactable = false;
            }
        }

        public void SpendHint()
        {
            Time.timeScale = 0;
            
            if (!GameManager.Instance.IsHintUsedInLevel(SceneManager.GetActiveScene().buildIndex) &&
                SceneManager.GetActiveScene().name != EXCLUDE_LEVEL)
            {
                GameManager.Instance.SetHintCoins(GameManager.Instance.GetHintCoins() - 1);
                GameManager.Instance.SetHintUsedInLevel(SceneManager.GetActiveScene().buildIndex);
            }
            
            GameManager.Instance.SetPause(true);
            
            if (GameManager.Instance.GetHintCoins() != 0)
            {
                return;    
            }

            _button.interactable = false;
        }

        public void ActivePlayerMovement()
        {
            Time.timeScale = 1;
            GameManager.Instance.SetPause(false);
        }
    }
}
