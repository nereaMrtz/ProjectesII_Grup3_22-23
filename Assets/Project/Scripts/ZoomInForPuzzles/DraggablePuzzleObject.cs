using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace Project.Scripts.ZoomInForPuzzles
{
    public abstract class DraggablePuzzleObject : MonoBehaviour
    {
        enum TypeOfDrag
        {
            ROTATE,
            MOVE
        };

        [SerializeField] private TypeOfDrag _typeOfDrag;

        [SerializeField] protected GameObject _gameObjectReference;

        private Vector3 _screenOffsetPoint;

        private void OnMouseDown()
        {
            _screenOffsetPoint = Camera.main.WorldToScreenPoint(_gameObjectReference.transform.position);
        }

        private void OnMouseDrag()
        {
            switch (_typeOfDrag)
            {
                case TypeOfDrag.ROTATE:

                    Vector3 vector = Input.mousePosition - _screenOffsetPoint;

                    float angle = -Quaternion.FromToRotation(vector, Vector3.up).eulerAngles.z;
                    
                    Vector3 directionVector = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.up;
                    transform.localPosition = _gameObjectReference.transform.localPosition +
                                              (transform.localPosition - _gameObjectReference.transform.localPosition).magnitude * directionVector;
                    
                    
                    Quaternion targetRotation = Quaternion.Euler(new Vector3(0,0,angle));
                    transform.localRotation = targetRotation;
                    break;
                
                case TypeOfDrag.MOVE:
                    transform.position = Vector2.MoveTowards(transform.position, GetMouseWorldCoordinates(),10 * Time.deltaTime );
                    break;
            }
        }
        
        private Vector3 GetMouseWorldCoordinates()
        {
            Vector3 mousePosition = Input.mousePosition;

            return Camera.main.ScreenToWorldPoint(mousePosition);
        }
    }
}
