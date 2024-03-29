using System;
using UnityEngine;

namespace Project.Scripts.Interactable.Static
{
    public abstract class UnlockableObject : MonoBehaviour
    {
        private const String INCORRECT_SOUND = "Incorrect Sound";
        
        protected bool _unlocked;        
        public abstract void Unlock();

        public bool IsUnlocked()
        {
            return _unlocked;
        }

        public void SetUnlock(bool unlocked)
        {
            _unlocked = unlocked;
        }
    }
}
