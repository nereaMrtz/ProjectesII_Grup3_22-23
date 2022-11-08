using System;
using System.Collections;
using Project.Scripts.Character;
using Project.Scripts.Sound;
using UnityEngine;


namespace Project.Scripts.Interactable.Static.RequiredInventory
{
    public class SimpleDoor : RequiredInventoryInteractable
    {
        private const String SIMPLE_DOOR_SOUND = "Simple Door Sound";
        private const String SLIDE_SIMPLE_DOOR_SOUND = "Slide Simple Door Sound";

        [SerializeField] private GameObject _key;
        
        private Transform _transform;

        [SerializeField] private bool _hidesToSides;

        private bool _unlocked;

        private float _width;
        private float _height;

        private void Start()
        {
            SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            Vector2 spriteRenderSize = spriteRenderer.size;
            _width = spriteRenderSize.x;
            _height = spriteRenderSize.y;
            _transform = transform;
        }

        public override void Interact(Inventory inventory, AudioManager audioManager)
        {
            InventorySlot[] inventorySlots = inventory.GetInventorySlots();
            
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                GameObject key = inventorySlots[i].GetPickUp().gameObject;
                if (key == _key)
                {
                    inventorySlots[i].EraseChildSprite();
                    Destroy(key);
                    StartCoroutine(MoveDoor(audioManager));
                    return;
                }
            }
            //SHOW POP UP
            return;
        }

        private IEnumerator MoveDoor(AudioManager audioManager)
        {
            audioManager.Play(SIMPLE_DOOR_SOUND);
            yield return new WaitForSeconds(audioManager.ClipDuration(SIMPLE_DOOR_SOUND));
            audioManager.Play(SLIDE_SIMPLE_DOOR_SOUND);
            
            Vector3 targetPosition = GetTargetPosition();

            float slideSoundDuration = audioManager.ClipDuration(SLIDE_SIMPLE_DOOR_SOUND);
            float distance = Vector2.Distance(_transform.position, targetPosition);
            float slideSpeed = distance / slideSoundDuration;
            
            while (Vector3.Distance(_transform.position, targetPosition) > 0)
            {
                float speed = slideSpeed * Time.deltaTime; 
                _transform.position = Vector2.MoveTowards(_transform.position, targetPosition, speed);
                yield return null;
            }
        }

        private Vector3 GetTargetPosition()
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

            return targetPosition;
        }
    }
}
