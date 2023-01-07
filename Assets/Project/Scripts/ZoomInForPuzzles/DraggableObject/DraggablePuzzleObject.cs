using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace Project.Scripts.ZoomInForPuzzles.DraggableObject
{
    public abstract class DraggablePuzzleObject : MonoBehaviour
    {
        private Vector3 _screenOffsetPoint;

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
