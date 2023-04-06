using UnityEngine;

namespace Project.Scripts.ZoomInForPuzzles.DraggableObject.Rotable
{
    public abstract class RotableObject : DraggablePuzzleObject
    {

        [SerializeField] private GameObject _gameObjectReference;
        
        private Vector3 _screenOffsetPoint;

        private float _offsetAngle;
        private float _initialMouseAngle;

        private void OnMouseDown()
        {
            _offsetAngle = transform.localEulerAngles.z;
            _screenOffsetPoint = Camera.main.WorldToScreenPoint(_gameObjectReference.transform.position);
            Vector3 initialMouseVector = Input.mousePosition - _screenOffsetPoint;
            _initialMouseAngle = Quaternion.FromToRotation(initialMouseVector, Vector3.up).eulerAngles.z;
        }
        
        protected override void Move()
        {
            Vector3 currentMouseVector = Input.mousePosition - _screenOffsetPoint;
            float currentAngle = Quaternion.FromToRotation(currentMouseVector, Vector3.up).eulerAngles.z;
            
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0,0, -(currentAngle - _initialMouseAngle - _offsetAngle)));
            transform.localRotation = targetRotation;
        }
    }
}
