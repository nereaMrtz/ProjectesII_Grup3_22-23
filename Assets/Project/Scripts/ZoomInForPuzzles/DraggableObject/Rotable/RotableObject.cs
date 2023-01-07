using UnityEngine;

namespace Project.Scripts.ZoomInForPuzzles.DraggableObject.Rotable
{
    public abstract class RotableObject : DraggablePuzzleObject
    {

        [SerializeField] private GameObject _gameObjectReference;
        
        private Vector3 _screenOffsetPoint;

        private void OnMouseDown()
        {
            _screenOffsetPoint = Camera.main.WorldToScreenPoint(_gameObjectReference.transform.position);
        }
        
        protected override void Move()
        {
            Vector3 vector = Input.mousePosition - _screenOffsetPoint;

            float angle = -Quaternion.FromToRotation(vector, Vector3.up).eulerAngles.z;
                    
            Vector3 directionVector = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.up;
            transform.localPosition = _gameObjectReference.transform.localPosition +
                                      (transform.localPosition - _gameObjectReference.transform.localPosition).magnitude * directionVector;
                    
                    
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0,0,angle));
            transform.localRotation = targetRotation;
        }
    }
}
