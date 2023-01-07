using UnityEngine;

namespace Project.Scripts.ZoomInForPuzzles.DraggableObject.Movable
{
    public abstract class MovableObject : DraggablePuzzleObject
    {
        [SerializeField] protected GameObject[] _destinations;
        
        protected override void Move()
        {
            transform.position = Vector2.MoveTowards(transform.position, 
                GetMouseWorldCoordinates(),10 * Time.deltaTime);
        }
    }
}
