using System.Collections;
using System.Collections.Generic;
using Project.Scripts.Interactable.PickUps;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Character
{
    public class InventorySlot : MonoBehaviour
    {
        [SerializeField] private Image _childSpriteRenderer;
    
        [SerializeField] private PickUp _pickUp;

        public void SetPickUp(PickUp pickUp)
        {
            _pickUp = pickUp;
            _childSpriteRenderer.sprite = _pickUp.gameObject.GetComponent<SpriteRenderer>().sprite;
        }

        public PickUp GetPickUp()
        {
            return _pickUp;
        }
    }
}

