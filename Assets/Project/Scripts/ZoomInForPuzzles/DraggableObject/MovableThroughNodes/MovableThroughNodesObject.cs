using Project.Scripts.ZoomInForPuzzles.DraggableObject.MovableThroughNodes.Nodes;
using UnityEngine;

namespace Project.Scripts.ZoomInForPuzzles.DraggableObject.MovableThroughNodes
{
    public abstract class MovableThroughNodesObject : DraggablePuzzleObject
    {
        [SerializeField] protected GameObject[] _destinations;
        
        [SerializeField] protected Node _currentNode;

        protected Node _nextNode;
        
        protected override void Move()
        {
            //transform.position = Vector2.Lerp(_currentNode, _nextNode, );
        }
    }
}
