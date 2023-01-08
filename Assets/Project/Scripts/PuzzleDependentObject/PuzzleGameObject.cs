using System;
using UnityEngine;

namespace Project.Scripts.PuzzleDependentObject
{
    public class PuzzleGameObject : PuzzleDependentObjectScript
    {
        [SerializeField] private Animator _animator;

        [SerializeField] private String _animationParameterName;
        
        protected override void ActionBehaviour()
        {
            //_animator.SetTrigger(_animationParameterName);
            gameObject.SetActive(true);
        }
    }
}
