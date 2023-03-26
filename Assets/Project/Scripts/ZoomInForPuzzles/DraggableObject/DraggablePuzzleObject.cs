using UnityEngine;

namespace Project.Scripts.ZoomInForPuzzles.DraggableObject
{
    public abstract class DraggablePuzzleObject : MonoBehaviour
    {
        private void OnMouseDrag()
        {
            Move();
        }
        
        protected Vector3 GetMouseWorldCoordinates()
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        protected abstract void Move();
    }
}
