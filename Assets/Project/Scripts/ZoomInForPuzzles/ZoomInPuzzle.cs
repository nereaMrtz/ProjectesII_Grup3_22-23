using Project.Scripts.Managers;
using Project.Scripts.Puzzle;
using UnityEngine;

namespace Project.Scripts.ZoomInForPuzzles
{
    public class ZoomInPuzzle : ZoomIn
    {
        [SerializeField] protected PuzzleScript _puzzle;
        
        void Update()
        {
            if (!_puzzle.GetCompleted()) return;
            gameObject.layer = 0;
            GameManager.Instance.SetZoomInState(!GameManager.Instance.IsInZoomInState());
            Destroy(this);
        }
    }
}
