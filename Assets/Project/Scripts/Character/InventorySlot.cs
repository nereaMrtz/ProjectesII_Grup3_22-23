using Project.Scripts.Interactable.PickUps;
using Project.Scripts.Interactable.Static.RequiredInventory;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Character
{
    public class InventorySlot : MonoBehaviour
    {
        [SerializeField] private Image _childSpriteRenderer;

        [SerializeField] private Sprite _emptySlotChildSprite;
    
        [SerializeField] private RequiredInventoryInteractable _pickUp;

        public void SetPickUp(RequiredInventoryInteractable pickUp)
        {
            _pickUp = pickUp;
            _childSpriteRenderer.sprite = _pickUp.gameObject.GetComponent<SpriteRenderer>().sprite;
            pickUp.gameObject.transform.SetParent(transform);
        }

        public RequiredInventoryInteractable GetPickUp()
        {
            return _pickUp;
        }

        public void EraseChildSprite()
        {
            _childSpriteRenderer.sprite = _emptySlotChildSprite;
        }
    }
}

