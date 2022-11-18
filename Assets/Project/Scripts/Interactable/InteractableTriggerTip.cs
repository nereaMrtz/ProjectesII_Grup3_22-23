using UnityEngine;
using Project.Scripts.UI;

namespace Project.Scripts.Interactable 
{
    public class InteractableTriggerTip : MonoBehaviour
    {
        private const int PLAYER_LAYER = 6;

        [SerializeField] private ObjectTip _tipText;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == PLAYER_LAYER)
            {
                _tipText.gameObject.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.layer == PLAYER_LAYER && _tipText != null)
            {
                _tipText.gameObject.SetActive(false);
            }
        }

        public ObjectTip GetObjectTip()
        {
            return _tipText;
        }
    }
}