using System;
using System.Collections;
using Project.Scripts.Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.Scripts.UI
{
    public abstract class HoverTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] protected GameObject _gameObjectAttached;

        [SerializeField] protected float timeToTipToAppear = 0.5f;

        protected RectTransform _rectTransform;
        
        protected String _tipText;

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
