using System;
using Project.Scripts.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Project.Scripts.UI
{
    public class HintButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private void OnEnable()
        {
            if (GameManager.Instance.GetHintCoins() == 0)
            {
                _button.interactable = false;
            }
        }

        public void StopPlayerMovement()
        {
            Time.timeScale = 0;
            
            if (!GameManager.Instance.IsHintUsedInLevel(SceneManager.GetActiveScene().buildIndex))
            {
                GameManager.Instance.SetHintCoins(GameManager.Instance.GetHintCoins() - 1);
                GameManager.Instance.SetHintUsedInLevel(SceneManager.GetActiveScene().buildIndex);
            }
            
            GameManager.Instance.SetZoomInState(true);
            
            if (GameManager.Instance.GetHintCoins() != 0)
            {
                return;    
            }

            _button.interactable = false;
        }

        public void ActivePlayerMovement()
        {
            Time.timeScale = 1;
            GameManager.Instance.SetZoomInState(false);
        }
    }
}
