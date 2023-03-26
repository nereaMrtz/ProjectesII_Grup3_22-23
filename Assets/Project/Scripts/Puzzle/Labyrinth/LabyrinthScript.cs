using UnityEngine;

namespace Project.Scripts.Puzzle.Labyrinth
{
    public class LabyrinthScript : PuzzleScript
    {
        [SerializeField] private ObjectGoingThroughMaze _objectGoingThroughMaze;

        [SerializeField] private GameObject _gameObjectToActivate;

        protected void Update()
        {
            _completed = _objectGoingThroughMaze.CheckEndCell();

            if (!_completed)
            {
                return;
            }
            _onComplete.Invoke();
            _gameObjectToActivate.SetActive(true);
        }
    }
}
