using System.Collections;
using Project.Scripts.ZoomInForPuzzles;
using UnityEngine;

namespace Project.Scripts.Puzzle.Labyrinth
{
    public class ObjectGoingThroughMaze : DraggablePuzzleObject
    {
        [SerializeField] private float _range;

        public bool CheckEndCell()
        {
            return Vector3.Distance(transform.localPosition, _gameObjectReference.transform.position) < _range;
        }
    }
}
