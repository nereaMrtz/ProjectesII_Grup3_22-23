using Project.Scripts.Interactable.PickUps;
using Project.Scripts.Interactable.Static.RequiredInventory;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Character
{
    public class InventorySlot : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        [SerializeField] private Sprite _emptySlotChildSprite;
    
        [SerializeField] private PickUp _pickUp;

        public void SetPickUp(PickUp pickUp)
        {
            _pickUp = pickUp;
            _spriteRenderer.sprite = _pickUp.gameObject.GetComponent<SpriteRenderer>().sprite;
            Vector2 size = _spriteRenderer.size;
            size = new Vector2(35f, 35f);
            _spriteRenderer.size = size;
            pickUp.gameObject.transform.SetParent(transform);
        }

        public PickUp GetPickUp()
        {
            return _pickUp;
        }

        public void EraseChildSprite()
        {
            _spriteRenderer.sprite = _emptySlotChildSprite;
        }
    }
}

