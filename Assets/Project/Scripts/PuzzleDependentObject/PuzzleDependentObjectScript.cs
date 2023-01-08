using System;
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
                if (gameObject.name == "Picture")
                {
                    Debug.Log("No");
                }
                return;
            }
            if (gameObject.name == "Picture")
            {
                Debug.Log("Yes");
            }
            ActionBehaviour();
        }

        protected abstract void ActionBehaviour();
    }
}
