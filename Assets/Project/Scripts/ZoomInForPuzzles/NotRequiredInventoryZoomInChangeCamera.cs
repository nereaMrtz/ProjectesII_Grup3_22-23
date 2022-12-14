using System;
using Project.Scripts.Managers;
using Project.Scripts.Puzzle;
using UnityEngine;

namespace Project.Scripts.ZoomInForPuzzles
{
    public class NotRequiredInventoryZoomInChangeCamera : NotRequiredInventoryZoomIn
    {
        protected const String OVER_WORLD_CAMERA_STATE = "OverWorldCamera"; 
        protected const String PUZZLE_CAMERA_STATE = "PuzzleCamera"; 
        
        [SerializeField] protected PuzzleScript _puzzle;

        [SerializeField] protected Animator _cameraSwitcherAnimator;

        private bool _overWorldCamera = true;
        
        public override void Interact()
        {
            base.Interact();

            SwitchCamera();
        }

        void Update()
        {
            if (!_puzzle.GetCompleted()) return;
            gameObject.layer = 0;
            _pointButton.SetActive(false);
        }

        public void SwitchCamera()
        {
            _cameraSwitcherAnimator.Play(_overWorldCamera ? PUZZLE_CAMERA_STATE : OVER_WORLD_CAMERA_STATE);
            _overWorldCamera = !_overWorldCamera;
        }
    }
}
