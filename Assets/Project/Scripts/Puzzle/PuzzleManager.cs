using UnityEngine;

namespace Project.Scripts.Puzzle
{
    public class PuzzleManager : MonoBehaviour
    {
        [SerializeField] private PuzzleScript[] _puzzleScripts;

        private int _currentPuzzle;
        
        private void Start()
        {
            _currentPuzzle = 0;
            _puzzleScripts[_currentPuzzle].Unlock();
        }

        private void Update()
        {
            if (_puzzleScripts[_currentPuzzle].GetCompleted())
            {
                _currentPuzzle++;
                if (_currentPuzzle == _puzzleScripts.Length)
                {
                    Destroy(gameObject);
                }
                else
                {
                    _puzzleScripts[_currentPuzzle].Unlock();    
                }
            }
        }
    }
}

