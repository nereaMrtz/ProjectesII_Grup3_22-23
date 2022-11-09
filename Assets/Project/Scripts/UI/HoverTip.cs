using System;
using System.Collections;
using Project.Scripts.Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.Scripts.UI
{
    public class HoverTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private GameObject _gameObjectAttached;

        [SerializeField] private float timeToTipToAppear = 0.5f;

        private RectTransform _rectTransform;

        private SpriteRenderer _spriteRendererOfGameObjectAttached;
        
        private String _tipText;

        private void Start()
        {
            _spriteRendererOfGameObjectAttached = _gameObjectAttached.GetComponent<SpriteRenderer>();
            _rectTransform = gameObject.GetComponent<RectTransform>();
            _tipText = _gameObjectAttached.name;
        }

        private void Update()
        {
            transform.position = _gameObjectAttached.transform.position;
            _rectTransform.sizeDelta = _spriteRendererOfGameObjectAttached.size * 32;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            StopAllCoroutines();
            StartCoroutine(StartTimer());
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            StopAllCoroutines();
            HoverTipManager.OnMouseLoseFocus();
        }

        private void ShowTip()
        {
            HoverTipManager.OnMouseHover(_tipText, Input.mousePosition);
        }

        private IEnumerator StartTimer()
        {
            yield return new WaitForSecondsRealtime(timeToTipToAppear);
            ShowTip();
        }
    }
}
