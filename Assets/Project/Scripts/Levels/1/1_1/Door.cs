using System;
using Project.Scripts.Interactable.Static;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1._1_1
{
    public class Door : UnlockableObject
    {
        private const String SIMPLE_DOOR_SOUND = "Simple Door Sound";
        private const String OPEN_TRIGGER = "Open";
        private const String CLOSE_TRIGGER = "Close";
        
        [SerializeField] protected Animator _animator;

        [SerializeField] private PolygonCollider2D[] _polygonCollider2Ds;

        private int _currentPolygonColliderIndex;
        
        public override void Unlock()
        {
            AudioManager.Instance.Play(SIMPLE_DOOR_SOUND);
            _animator.SetTrigger(OPEN_TRIGGER);
            gameObject.layer = 0;
            _unlocked = true;
        }

        public void CloseDoor()
        {
            AudioManager.Instance.Play(SIMPLE_DOOR_SOUND);
            _animator.SetTrigger(CLOSE_TRIGGER);
            gameObject.layer = 0;
            _unlocked = false;
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

        public void ChangePolygonCollider(int index)
        {
            _polygonCollider2Ds[index].enabled = true;
            _polygonCollider2Ds[_currentPolygonColliderIndex].enabled = false;
            _currentPolygonColliderIndex = index;
        }
    }
}
