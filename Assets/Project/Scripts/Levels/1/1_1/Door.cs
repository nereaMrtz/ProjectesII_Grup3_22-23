using System;
using System.Collections;
using Project.Scripts.Interactable.Static;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1._1._1
{
    public class Door : UnlockableObject
    {
        private const String SIMPLE_DOOR_SOUND = "Simple Door Sound";
        private const String OPEN_TRIGGER = "Open";
        private const String HORIZONTAL_OPENING_DOOR_STATE = "HorizontalOpeningDoor";
        
        [SerializeField] private Animator _animator;
        
        public override void Unlock()
        {
            AudioManager.Instance.Play(SIMPLE_DOOR_SOUND);
            _animator.SetTrigger(OPEN_TRIGGER);
            StartCoroutine(BakeScenario(ReturnAnimationClipByName(HORIZONTAL_OPENING_DOOR_STATE).length));
            gameObject.layer = 0;
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
        
        private IEnumerator BakeScenario(float time)
        {
            yield return new WaitForSeconds(time);
            NavMeshManager.Instance.Bake();
        }
    }
}
