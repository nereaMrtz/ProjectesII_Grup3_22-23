using Project.Scripts.ZoomInForPuzzles.DraggableObject.Movable;
using UnityEngine;

namespace Project.Scripts.Puzzle.Labyrinth
{
    public class ObjectGoingThroughMaze : MovableObject
    {
        [SerializeField] private float _range;

        public bool CheckEndCell()
        {
            return Vector3.Distance(transform.localPosition, _destinations[0].transform.position) < _range;
        }
    }
}
