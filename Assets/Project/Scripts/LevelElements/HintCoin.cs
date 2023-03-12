using Project.Scripts.Managers;
using Project.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.LevelElements
{
    public class HintCoin : MonoBehaviour
    {
        private const int PLAYER_LAYER = 6;

        [SerializeField] private InGameUI _inGameUI;
        
        [SerializeField] private Button _button;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            
            if (GameManager.Instance.GetHintCoins() == 0)
            {
                _button.interactable = true;
            }
            GameManager.Instance.SetHintCoins(GameManager.Instance.GetHintCoins() + 1);
            _inGameUI.UpdateCoinsMarker();
            Destroy(gameObject);
        }
    }
}
