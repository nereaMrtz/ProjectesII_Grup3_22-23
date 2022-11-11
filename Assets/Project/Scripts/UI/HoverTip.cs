using System;
using System.Collections;
using Project.Scripts.Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.Scripts.UI
{
    public abstract class HoverTip : MonoBehaviour
    {
        private const String PLAYER_TRIGER_TIP_LAYER = "Player Trigger Tip";

        [SerializeField] protected GameObject _gameObjectAttached;

        protected RectTransform _rectTransform;
        
        protected String _tipText;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.GetMask(PLAYER_TRIGER_TIP_LAYER))
            {
                HoverTipManager.OnPlayerTriggerEnter(_tipText, _gameObjectAttached.transform.position);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.GetMask(PLAYER_TRIGER_TIP_LAYER))
            {
                HoverTipManager.OnPlayerTriggerEnter(_tipText, _gameObjectAttached.transform.position);
            }
        }

    }
}
