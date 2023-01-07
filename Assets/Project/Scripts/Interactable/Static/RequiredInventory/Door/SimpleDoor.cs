using System;
using System.Collections;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Interactable.Static.RequiredInventory.Door
{
    public class SimpleDoor : UnlockableObject
    {
        private const String SIMPLE_DOOR_SOUND = "Simple Door Sound";
        private const String SLIDE_SIMPLE_DOOR_SOUND = "Slide Simple Door Sound";
        
        private const String OPEN_TRIGGER_STATE = "Open";
        private const String CLOSE_TRIGGER_STATE = "Close";

        [SerializeField] private Animator _animator;

        [SerializeField] private BoxCollider2D _boxCollider2D;
        
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        private Transform _transform;

        private bool _moved;

        private void Start()
        {
            _transform = transform;
        }

        protected override void Unlock()
        {
            MoveDoor();
        }

        private void MoveDoor()
        {
            _spriteRenderer.sortingOrder--;
            AudioManager.Instance.Play(SIMPLE_DOOR_SOUND);
            _animator.SetTrigger(OPEN_TRIGGER_STATE);
            NavMeshManager.Instance.Bake();
        }
    }
}
