using System;
using System.Collections;
using Project.Scripts.Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.Scripts.UI
{
    public abstract class HoverTip : MonoBehaviour
    {
        [SerializeField] protected GameObject _gameObjectAttached;

        [SerializeField] protected String _tipText;
        [SerializeField] protected String _longText;

        private RectTransform _rectTransform;

        private void Start()
        {
            _rectTransform = gameObject.GetComponent<RectTransform>();
        }

        public void OnView()
        {
            HoverTipManager.OnView(_tipText, _gameObjectAttached.transform.position);
        }

        public void OffView()
        {
            HoverTipManager.OffView();
        }

    }
}
