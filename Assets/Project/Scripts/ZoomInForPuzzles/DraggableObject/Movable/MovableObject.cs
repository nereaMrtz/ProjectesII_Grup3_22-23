using UnityEngine;

namespace Project.Scripts.ZoomInForPuzzles.DraggableObject.Movable
{
    public abstract class MovableObject : DraggablePuzzleObject
    {
        [SerializeField] protected Vector3 _goalPosition;
    }
}
