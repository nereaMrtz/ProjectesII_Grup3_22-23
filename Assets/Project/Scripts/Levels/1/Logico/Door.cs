using System;
using Project.Scripts.Interactable.Static;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1._1_1
{
    public class Door : UnlockableObject
    {
        protected const String SIMPLE_DOOR_SOUND = "Simple Door Sound";
        protected const String OPEN_TRIGGER = "Open";
        protected const String CLOSE_TRIGGER = "Close";
        
        [SerializeField] protected Animator _animator;

        [SerializeField] protected PolygonCollider2D[] _collisionPolygonCollider2Ds;
        [SerializeField] protected PolygonCollider2D[] _triggerPolygonCollider2Ds;

        protected int _currentPolygonColliderIndex;

        protected AudioSource _audioSource;

        private void Awake()
        {
            GameObject audioGameObject = new GameObject();
            audioGameObject.name = "AudioSource";
            _audioSource = audioGameObject.AddComponent<AudioSource>();
            AudioManager.Instance.SetAudioSourceComponent(_audioSource, SIMPLE_DOOR_SOUND);
            audioGameObject.transform.parent = gameObject.transform;
            audioGameObject.transform.localPosition = new Vector3(0.725f, 0.985f, 0);
        }

        public override void Unlock()
        {
            _audioSource.Play();
            _animator.SetTrigger(OPEN_TRIGGER);
            _unlocked = true;
        }

        public void CloseDoor()
        {
            _animator.SetTrigger(CLOSE_TRIGGER);
            _unlocked = false;
        }

        public void ChangePolygonCollider(int index)
        {
            _collisionPolygonCollider2Ds[_currentPolygonColliderIndex].enabled = false;
            _collisionPolygonCollider2Ds[index].enabled = true;

            if (_triggerPolygonCollider2Ds.Length != 0)
            {
                _triggerPolygonCollider2Ds[_currentPolygonColliderIndex].enabled = false;
                _triggerPolygonCollider2Ds[index].enabled = true;
            }

            _currentPolygonColliderIndex = index;
        }
    }
}
