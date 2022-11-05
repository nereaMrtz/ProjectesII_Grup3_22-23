using System;
using System.Collections;
using Project.Scripts.Character;
using UnityEngine;


namespace Project.Scripts.Interactable.Static
{
    public class SimpleDoor : InteractableScript
    {
        private Transform _transform;

        private float _width;
        private float _height;

        [SerializeField] private bool _unlocked;
        [SerializeField] private bool _hidesToSides;

        [SerializeField] private GameObject _key;

        private void Start()
        {
            SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            _width = spriteRenderer.size.x;
            _height = spriteRenderer.size.y;
            _transform = gameObject.transform;
        }

        private void Update()
        {
            if (_unlocked)
            {
                StartCoroutine(Open());
                _unlocked = false;
            }
        }

        public override void Interact(Inventory inventory)
        {
            InventorySlot[] inventorySlots = inventory.GetInventorySlots();
            
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                GameObject key = inventorySlots[i].GetPickUp().gameObject;
                if (key == _key)
                {
                    inventorySlots[i].EraseChildSprite();
                    Destroy(key);
                    StartCoroutine(Open());
                    return;
                }
            }
            //SHOW POP UP
            return;
        }

        private IEnumerator Open()
        {
            Vector2 targetPosition;
            
            if (_hidesToSides)
            {
                targetPosition = new Vector2(_transform.position.x + _width, _transform.position.y);
            }
            else
            {
                targetPosition = new Vector2(_transform.position.x, _transform.position.y + _height);
            }
            
            while (Vector3.Distance(_transform.position, targetPosition) > 0)
            {
                _transform.position = Vector2.MoveTowards(_transform.position, targetPosition, 2 * Time.deltaTime);
                yield return null;
            }
        }
    }
}
