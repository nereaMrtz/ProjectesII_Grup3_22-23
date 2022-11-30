using Project.Scripts.Sound;
using UnityEngine;

namespace Project.Scripts.Interactable.Static
{
    public abstract class LockableObject : UnlockableObject
    {
        protected override void Unlock(AudioManager audioManager)
        {
            throw new System.NotImplementedException();
        }

        protected abstract void Lock(AudioManager audioManager);

        public bool GetUnlocked()
        {
            return _unlocked;
        }

        public void SetUnlocked(bool unlock)
        {
            _unlocked = unlock;
        }
    }
}
