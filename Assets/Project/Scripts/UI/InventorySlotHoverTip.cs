using Project.Scripts.Character;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.Scripts.UI
{
    public class InventorySlotHoverTip : HoverTip, IPointerClickHandler
    {
        void Start()
        {
            transform.position = _gameObjectAttached.transform.position;
            _rectTransform = gameObject.GetComponent<RectTransform>();
        }

        void Update()
        {
            if (_gameObjectAttached.transform.childCount < 1)
            {
                _tipText = _gameObjectAttached.name;
                return;   
            }
            _tipText = _gameObjectAttached.GetComponent<InventorySlot>().GetPickUp().name;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }
    }
}
