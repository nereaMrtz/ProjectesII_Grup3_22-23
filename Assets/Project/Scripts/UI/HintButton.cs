using Project.Scripts.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Project.Scripts.UI
{
    public class HintButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        [SerializeField] private Image _image;
        
        public void StopPlayerMovement()
        {
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
            
            _button.enabled = false;
            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, _image.color.a / 2);
        }

        public void ActivePlayerMovement()
        {
            GameManager.Instance.SetZoomInState(false);
        }
    }
}
