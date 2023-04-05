using System;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Interactable.Static.RequiredInventory.Door
{
    public class SimpleDoor : UnlockableObject
    {
        private const String SIMPLE_DOOR_SOUND = "Simple Door Sound";
        
        private const String OPEN_TRIGGER = "Open";
        private const String CLOSE_TRIGGER = "Close";

        [SerializeField] private Animator _animator;

        private AudioSource _audioSource;

        private bool _moved;

        private void Start()
        {
            AudioManager.Instance.SetAudioSourceComponent(_audioSource, SIMPLE_DOOR_SOUND);
        }

        public override void Unlock()
        {
            MoveDoor();
        }

        private void MoveDoor()
        {
            _audioSource.Play();
            _animator.SetTrigger(OPEN_TRIGGER);
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
    }
}
