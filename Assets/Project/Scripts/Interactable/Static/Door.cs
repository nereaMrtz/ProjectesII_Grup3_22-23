using System;
using System.Collections;
using UnityEngine;


namespace Project.Scripts.Interactable.Static
{
    public class Door : InteractableScript
    {
        private Transform _transform;

        private float _width;
        private float _height;

        private bool _unlocked;
        [SerializeField] private bool _hidesToSides; 

        private void Start()
        {
            SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            _width = spriteRenderer.size.x;
            _height = spriteRenderer.size.y;
            _transform = gameObject.transform;
        }

        public override void Interact()
        {
            if (_unlocked)
            {
                StartCoroutine(Open());
            }
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
