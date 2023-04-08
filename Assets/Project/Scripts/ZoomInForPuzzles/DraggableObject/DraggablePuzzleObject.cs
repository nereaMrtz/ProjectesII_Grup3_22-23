using UnityEngine;

namespace Project.Scripts.ZoomInForPuzzles.DraggableObject
{
    public abstract class DraggablePuzzleObject : MonoBehaviour
    {
        protected Vector3 _initialPosition;
        protected Vector3 _currentPosition;
        protected Vector3 _initialMousePosition;
        protected Vector3 _currentMousePosition;

        protected void Start()
        {
            _initialPosition = transform.localPosition;
            _currentPosition = _initialPosition;
        }
        
        protected void OnMouseDown()
        {
            _initialMousePosition = GetMouseWorldCoordinates();
            _currentPosition = transform.localPosition;
        }
        
        private void OnMouseDrag()
        {
            _currentMousePosition = GetMouseWorldCoordinates();
            Move();
        }
        
        public Vector3 GetMouseWorldCoordinates()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            return mousePosition;
        }

        protected abstract void Move();
    }
}
