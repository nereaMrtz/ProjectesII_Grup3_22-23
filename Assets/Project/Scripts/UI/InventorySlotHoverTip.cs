using Project.Scripts.Character;
using Project.Scripts.Interactable.PickUps;
using UnityEngine;

namespace Project.Scripts.UI
{
    public class InventorySlotHoverTip : HoverTip
    {
        void Start()
        {
            transform.position = _gameObjectAttached.transform.position;
            _rectTransform = gameObject.GetComponent<RectTransform>();
            if (_gameObjectAttached.transform.childCount == 2)
            {
                
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (_gameObjectAttached.transform.childCount < 2)
            {
                _tipText = _gameObjectAttached.name;
                return;   
            }
            _tipText = _gameObjectAttached.GetComponent<InventorySlot>().GetPickUp().name;
            //_rectTransform.sizeDelta = _spriteRendererOfGameObjectAttached.size;
        }
    }
}
