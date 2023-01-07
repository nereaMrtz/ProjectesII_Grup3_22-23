using System;
using UnityEngine;

namespace Project.Scripts.Puzzle.Labyrinth
{
    public class LabyrinthScript : PuzzleScript
    {
        [SerializeField] private ObjectGoingThroughMaze _objectGoingThroughMaze;

        protected void Update()
        {
            _completed = _objectGoingThroughMaze.CheckEndCell();
        }
    }
}
