using System;
using Cinemachine;
using Project.Scripts.Managers;
using Project.Scripts.Puzzle;
using UnityEngine;

namespace Project.Scripts.ZoomInForPuzzles
{
    public class ZoomInChangeCamera : ZoomIn
    {
        private const String OVER_WORLD_CAMERA_STATE = "OverWorldCamera"; 
        private const String PUZZLE_CAMERA_STATE = "PuzzleCamera"; 
        
        [SerializeField] private PuzzleScript _puzzle;

        [SerializeField] private Animator _cameraSwitcherAnimator;

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
            SwitchCamera();
            _puzzle.gameObject.SetActive(false);
            GameManager.Instance.SetZoomInState(!GameManager.Instance.IsInZoomInState());
            Destroy(this);
        }

        private void SwitchCamera()
        {
            _cameraSwitcherAnimator.Play(_overWorldCamera ? PUZZLE_CAMERA_STATE : OVER_WORLD_CAMERA_STATE);

            _overWorldCamera = !_overWorldCamera;
        }
    }
}
