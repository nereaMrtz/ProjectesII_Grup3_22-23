using System.Collections;
using Project.Scripts.ZoomInForPuzzles;
using Project.Scripts.ZoomInForPuzzles.DraggableObject;
using Project.Scripts.ZoomInForPuzzles.DraggableObject.MovableThroughNodes;
using UnityEngine;

namespace Project.Scripts.Puzzle.Labyrinth
{
    public class ObjectGoingThroughMaze : MovableThroughNodesObject
    {
        [SerializeField] private float _range;

        public bool CheckEndCell()
        {
            return Vector3.Distance(transform.localPosition, _destinations[0].transform.position) < _range;
        }
    }
}
