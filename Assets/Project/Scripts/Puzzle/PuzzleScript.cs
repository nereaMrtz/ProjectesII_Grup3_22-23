using System;
using UnityEngine;

namespace Project.Scripts.Puzzle
{
    public abstract class PuzzleScript : MonoBehaviour
    {
        protected bool _completed;
        public bool GetCompleted()
        {
            return _completed;
        }
    } 
}

