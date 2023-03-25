using Project.Scripts.Interactable.Static;
using UnityEngine;

namespace Project.Scripts.Levels._1.Telequinesis
{
    public class Door_Telequinesis : MonoBehaviour
    {
        [SerializeField] private UnlockableObject _door;
        
        private float _initialXPosition;
        private readonly float _goalXPosition = -6.438f;
        private float _initialMouseXPosition;
        private float _currentMouseXPosition;
        private float _currentMouseXDistanceFromOrigin;

        private void Start()
        {
            _initialXPosition = transform.localPosition.x;
        }

        private void OnMouseDown()
        {
            _initialMouseXPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        }

        private void OnMouseDrag()
        {
            _currentMouseXPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            _currentMouseXDistanceFromOrigin = _currentMouseXPosition - _initialMouseXPosition;
            if (transform.localPosition.x + _currentMouseXDistanceFromOrigin > _initialXPosition)
            {
                return;
            }
            if (_initialXPosition + _currentMouseXDistanceFromOrigin <= _goalXPosition)
            {
                transform.localPosition = new Vector3(_goalXPosition, transform.localPosition.y, 0);
                _door.Unlock();
                Destroy(this);
            }
            else
            {
                transform.localPosition = new Vector3(_initialXPosition + _currentMouseXDistanceFromOrigin, transform.localPosition.y, 0);    
            }
        }
    }
}