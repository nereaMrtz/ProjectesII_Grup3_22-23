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
        
        public override void Unlock()
        {
            AudioManager.Instance.Play(SIMPLE_DOOR_SOUND);
            _animator.SetTrigger(OPEN_TRIGGER);
            _unlocked = true;
        }

        public void CloseDoor()
        {
            //AudioManager.Instance.Play(SIMPLE_DOOR_SOUND);
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
