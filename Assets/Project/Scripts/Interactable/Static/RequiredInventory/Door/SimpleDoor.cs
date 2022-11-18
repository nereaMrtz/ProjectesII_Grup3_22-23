using System;
using System.Collections;
using Project.Scripts.Character;
using Project.Scripts.Sound;
using Project.Scripts.UI;
using UnityEngine;

namespace Project.Scripts.Interactable.Static.RequiredInventory.Door
{
    public class SimpleDoor : RequiredInventoryInteractable
    {
        private const String SIMPLE_DOOR_SOUND = "Simple Door Sound";
        private const String SLIDE_SIMPLE_DOOR_SOUND = "Slide Simple Door Sound";
        private const String INCORRECT_SOUND = "Incorrect Sound";

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
                if (inventorySlots[i].GetPickUp().gameObject.name == "EmptyInventorySlot")
                {
                    continue;
                }
                GameObject pickUp = inventorySlots[i].GetPickUp().gameObject;
                if (pickUp == _key)
                {
                    gameObject.transform.GetChild(0).gameObject.SetActive(false);
                    inventorySlots[i].EraseChildSprite();
                    for (int j = 0; j < pickUp.transform.childCount - 1; j++)
                    {
                        Destroy(pickUp.transform.GetChild(j).gameObject);
                    }
                    Destroy(pickUp);
                    StartCoroutine(MoveDoor(audioManager));
                    return;
                }
            }
            audioManager.Play(INCORRECT_SOUND);
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
                targetPosition = new Vector2(_transform.position.x, _transform.position.y - _height);
            }

            return targetPosition;
        }
    }
}
