using System;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.PuzzleDependentObject
{
    public class PuzzleDoor : PuzzleDependentObjectScript
    {
        private const String SIMPLE_DOOR_SOUND = "Simple Door Sound";
        private const String SLIDE_SIMPLE_DOOR_SOUND = "Slide Simple Door Sound";

        private const String OPEN_TRIGGER_STATE = "Open";
        private const String CLOSE_TRIGGER_STATE = "Close";

        private const String HORIZONTAL_OPENING_DOOR_STATE = "HorizontalOpeningDoor";

        [SerializeField] private SpriteRenderer _spriteRenderer;

        [SerializeField] private Animator _animator;

        private bool _moved;

        protected override void ActionBehaviour()
        {
            if (_moved)
            {
                return;
            }
            MoveDoor();
        }

        private void MoveDoor()
        {
            _moved = true;
            AudioManager.Instance.Play(SIMPLE_DOOR_SOUND);
            _animator.SetTrigger(OPEN_TRIGGER_STATE);
        }
        

        private AnimationClip ReturnAnimationClipByName(string name)
        {
            for (int i = 0; i < _animator.runtimeAnimatorController.animationClips.Length; i++)
            {
                if (_animator.runtimeAnimatorController.animationClips[i].name == name)
                {
                    return _animator.runtimeAnimatorController.animationClips[i];
                }
            }
            return null;
        }
    }
}
