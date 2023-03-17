using System;
using Project.Scripts.Interactable.Static;
using UnityEngine;
using UnityEngine.Audio;

namespace Project.Scripts.Levels._1.Shhhh
{
    public class DeafenYourself : MonoBehaviour
    {
        [SerializeField] private UnlockableObject _door;

        private void OnEnable()
        {
            if (_door.IsUnlocked())
            {
                return;
            }
            _door.Unlock();
        }
    }
}
