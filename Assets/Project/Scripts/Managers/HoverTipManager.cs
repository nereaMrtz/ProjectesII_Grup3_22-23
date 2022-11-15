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

        public static Action<string, Vector2> OnView;
        
        public static Action OffView;
        
        void Start()
        {
            HideText();
        }

        private void OnEnable()
        {
            OnView += ShowText;
            OffView += HideText;
        }

        private void OnDisable()
        {
            OnView -= ShowText;
            OffView -= HideText;
        }

        private void ShowText(string text, Vector2 objectPosition)
        {
            _tip.text = text;

            Vector2 sizeDelta = _tip.gameObject.GetComponent<RectTransform>().sizeDelta;

            _hoverTip.sizeDelta = new Vector2(sizeDelta.x > 500 ? 500 : sizeDelta.x, sizeDelta.y);
            _hoverTip.transform.position = new Vector2(objectPosition.x + OffsetX , objectPosition.y + OffsetY);
            _hoverTip.gameObject.SetActive(true);
        }

        private void HideText()
        {
            _tip.text = default;
            _hoverTip.gameObject.SetActive(false);
        }
    }
}
