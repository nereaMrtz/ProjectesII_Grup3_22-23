using Project.Scripts.Puzzle;
using UnityEngine;

namespace Project.Scripts.Managers
{
    public class PuzzleManager : MonoBehaviour
    {
        [SerializeField] private PuzzleScript[] _puzzleScripts;

        private int _currentPuzzle;
        
        private void Start()
        {
            _currentPuzzle = 0;
            _puzzleScripts[_currentPuzzle].gameObject.SetActive(true);
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
                    _puzzleScripts[_currentPuzzle].gameObject.SetActive(true);    
                }
            }
        }
    }
}

