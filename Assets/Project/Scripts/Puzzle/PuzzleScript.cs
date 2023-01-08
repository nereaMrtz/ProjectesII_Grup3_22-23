using System;
using Project.Scripts.Managers;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Scripts.Puzzle
{
    public abstract class PuzzleScript : MonoBehaviour
    {
        private const String CORRECT_SOUND = "Correcto";

        protected UnityEvent _onComplete;
        
        protected bool _completed;

        private void Start()
        {
            if (_onComplete == null)
            {
                _onComplete = new UnityEvent();
            }
            _onComplete.AddListener(CorrectSound);
        }

        public bool GetCompleted()
        {
            return _completed;
        }

        private void CorrectSound()
        {
            AudioManager.Instance.Play(CORRECT_SOUND);
            _onComplete.RemoveListener(CorrectSound);
        }
    } 
}

