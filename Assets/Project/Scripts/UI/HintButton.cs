using System;
using Project.Scripts.Managers;
using Project.Scripts.NoMonoBehaviourClass;
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
            if (!GameManager.Instance.IsHintUsedInLevel(SceneManager.GetActiveScene().buildIndex) &&
                GameManager.Instance.GetHintCoins() == 0 && SceneManager.GetActiveScene().name != EXCLUDE_LEVEL)
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
                GameManager.Instance.AlterCoins(-1);
                GameManager.Instance.SetHintUsedInLevel(SceneManager.GetActiveScene().buildIndex);
            }
            
            GameManager.Instance.SetPause(true);
        }

        public void ActivePlayerMovement()
        {
            Time.timeScale = 1;
            GameManager.Instance.SetPause(false);
        }
    }
}
