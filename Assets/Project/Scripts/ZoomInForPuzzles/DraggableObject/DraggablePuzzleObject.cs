using UnityEngine;

namespace Project.Scripts.ZoomInForPuzzles.DraggableObject
{
    public abstract class DraggablePuzzleObject : MonoBehaviour
    {
        protected Vector3 _initialPosition;
        protected Vector3 _currentPosition;
        protected Vector3 _initialMousePosition;
        protected Vector3 _currentMousePosition;

        private void Start()
        {
            _initialPosition = transform.localPosition;
            _currentPosition = _initialPosition;
        }
        
        private void OnMouseDown()
        {
            _initialMousePosition = GetMouseWorldCoordinates();
            _currentPosition = transform.localPosition;
        }
        
        private void OnMouseDrag()
        {
            _currentMousePosition = GetMouseWorldCoordinates();
            Move();
        }
        
        private Vector3 GetMouseWorldCoordinates()
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        protected abstract void Move();
    }
}
