using System;
using Project.Scripts.Managers;

namespace Project.Scripts.Interactable.Static
{
    public abstract class LockableObject : UnlockableObject
    {
        public override void Unlock()
        {
            throw new NotImplementedException();
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
