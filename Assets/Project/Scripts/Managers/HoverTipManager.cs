using System;
using TMPro;
using UnityEngine;

namespace Project.Scripts.Managers
{
    public class HoverTipManager : MonoBehaviour
    {
        [SerializeField] private RectTransform _hoverTip;
        
        [SerializeField] private TextMeshProUGUI _tip;

        [SerializeField] private float OffsetY;
        [SerializeField] private float OffsetX;

        public static Action<string, Vector2> OnMouseHover;
        
        public static Action OnMouseLoseFocus;
        
        void Start()
        {
            HideText();
        }

        private void OnEnable()
        {
            OnMouseHover += ShowText;
            OnMouseLoseFocus += HideText;
        }

        private void OnDisable()
        {
            OnMouseHover -= ShowText;
            OnMouseLoseFocus -= HideText;
        }

        private void ShowText(string text, Vector2 mousePosition)
        {
            _tip.text = text;

            Vector2 sizeDelta = _tip.gameObject.GetComponent<RectTransform>().sizeDelta;

            _hoverTip.sizeDelta = new Vector2(sizeDelta.x > 500 ? 500 : sizeDelta.x, sizeDelta.y);
            Vector2 mouseAtWorldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _hoverTip.transform.position = new Vector2(mouseAtWorldSpace.x + OffsetX , mouseAtWorldSpace.y + OffsetY);
            _hoverTip.gameObject.SetActive(true);
        }

        private void HideText()
        {
            _tip.text = default;
            _hoverTip.gameObject.SetActive(false);
        }
    }
}
