using System;
using System.Collections;
using Project.Scripts.Character;
using Project.Scripts.Sound;
using UnityEngine;

namespace Project.Scripts.Interactable.Static.RequiredInventory.Door
{
    public class SimpleDoor : UnlockableObject
    {
        private const String SIMPLE_DOOR_SOUND = "Simple Door Sound";
        private const String SLIDE_SIMPLE_DOOR_SOUND = "Slide Simple Door Sound";
        
        private Transform _transform;

        [SerializeField] private bool _hidesToSides;

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

        protected override void Unlock(AudioManager audioManager)
        {
            StartCoroutine(MoveDoor(audioManager));
        }

        protected override void Lock(AudioManager audioManager)
        {
            throw new NotImplementedException();
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
