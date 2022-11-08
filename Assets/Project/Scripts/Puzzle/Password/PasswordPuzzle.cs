using System;
using UnityEngine;

namespace Project.Scripts.Puzzle.Password
{
    public abstract class PasswordPuzzle : PuzzleScript
    {
        [SerializeField] private String _correctPassword;

        public bool IsCorrectPassword(String writtenPassword)
        {
            _completed = _correctPassword == writtenPassword;
            return _completed;
        }
    }    
}

