using System;
using Project.Scripts.Puzzle;
using UnityEngine;

namespace Project.Scripts.Interactable.Buttons
{
    public class BackPuzzleButton : Button
    {
        [SerializeField] private PuzzleScript _puzzle;

        [SerializeField] private Animator _animator;

        public void BackButton()
        {
            if (_puzzle.GetCompleted())
            {
                _animator.enabled = true;
            }
            ExitButton();
        }

    }
}
