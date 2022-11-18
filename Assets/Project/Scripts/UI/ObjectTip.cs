using System;
using TMPro;
using System.Collections;
using Project.Scripts.Managers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Project.Scripts.UI
{
    public class ObjectTip : MonoBehaviour
    {
        [SerializeField] private RectTransform _hoverTip;

        [SerializeField] private Image _image;

        [SerializeField] private TextMeshProUGUI _tip;

        [SerializeField] private float OffsetY;
        [SerializeField] private float OffsetX;

        [SerializeField] private GameObject _gameObjectAttached;

        [SerializeField] private String _tipText;
        [SerializeField] private String _longText;

        [SerializeField] private bool _activateTip;

        private bool _onView;        

        private void Start()
        {
            HideText();
        }

        private void Update()
        {
            if (_gameObjectAttached.activeSelf && _activateTip)
            {
                ShowText(_tipText, _gameObjectAttached.transform.position); 
            }
            else
            {
                HideText();
            }
        }

        private void ShowText(string text, Vector2 objectPosition)
        {
            _tip.text = text + "\nPress E to interact";
            _image.color = new Color(0, 0, 0, 0.38f);

            Vector2 sizeDelta = _tip.gameObject.GetComponent<RectTransform>().sizeDelta;

            _hoverTip.sizeDelta = new Vector2(sizeDelta.x > 500 ? 500 : sizeDelta.x, sizeDelta.y);
            _hoverTip.transform.position = new Vector2(objectPosition.x + OffsetX, objectPosition.y + OffsetY);
            _hoverTip.gameObject.SetActive(true);
        }

        private void HideText()
        {
            _tip.text = default;
            _image.color = new Color(0, 0, 0, 0);
        }

        public void SetActivateTip(bool activateTip)
        {
            _activateTip = activateTip;
        }
    }
}