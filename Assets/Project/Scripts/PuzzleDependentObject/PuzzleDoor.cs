using System;
using System.Collections;
using Project.Scripts.Interactable.Static;
using Project.Scripts.Managers;
using Project.Scripts.Puzzle;
using UnityEngine;

namespace Project.Scripts.PuzzleDependentObject
{
    public class PuzzleDoor : MonoBehaviour
    {
        private const String SIMPLE_DOOR_SOUND = "Simple Door Sound";
        private const String SLIDE_SIMPLE_DOOR_SOUND = "Slide Simple Door Sound";

        private const String OPEN_TRIGGER_STATE = "Open";
        private const String CLOSE_TRIGGER_STATE = "Close";

        [SerializeField] private SpriteRenderer _spriteRenderer;

        [SerializeField] private Animator _animator;
        
        [SerializeField] private PuzzleScript _puzzle;

        [SerializeField] private BoxCollider2D _boxCollider2D;
        
        private AudioManager _audioManager;

        private bool _moved;

        private void Start()
        {
            _audioManager = FindObjectOfType<AudioManager>();
        }

        private void Update()
        {
            if (_puzzle.GetCompleted() && !_moved)
            {
                MoveDoor(_audioManager);
            }
        }

        private void MoveDoor(AudioManager audioManager)
        {
            _moved = true;
            _spriteRenderer.sortingOrder--;
            audioManager.Play(SIMPLE_DOOR_SOUND);
            _animator.SetTrigger(OPEN_TRIGGER_STATE);
            NavMeshManager.Instance.Bake();
        }
    }
}
