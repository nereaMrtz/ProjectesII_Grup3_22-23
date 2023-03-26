using Project.Scripts.Puzzle;
using UnityEngine;

namespace Project.Scripts.PuzzleDependentObject
{
    public abstract class PuzzleDependentObjectScript : MonoBehaviour
    {
        
        [SerializeField] protected PuzzleScript _puzzle;

        private void Update()
        {
            if (!_puzzle.GetCompleted())
            {
                return;
            }
            ActionBehaviour();
        }

        protected abstract void ActionBehaviour();
    }
}
