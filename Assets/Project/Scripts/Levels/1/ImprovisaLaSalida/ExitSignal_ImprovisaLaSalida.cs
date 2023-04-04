using Project.Scripts.Interactable.Static;
using Project.Scripts.ZoomInForPuzzles.DraggableObject.Movable;
using UnityEngine;

namespace Project.Scripts.Levels._1.ImprovisaLaSalida
{
    public class ExitSignal_ImprovisaLaSalida : MovableObject
    {
        
        [SerializeField] private UnlockableObject _door;
            
        private float _currentMouseXDistanceFromOrigin;
        
        protected override void Move()
        {
            _currentMouseXDistanceFromOrigin = (_currentMousePosition.x - _initialMousePosition.x) + (_currentPosition.x - _initialPosition.x);
                
            if (transform.localPosition.x + _currentMouseXDistanceFromOrigin < _initialPosition.x)
            {
                return;
            }
            if (_initialPosition.x + _currentMouseXDistanceFromOrigin >= _goalPosition.x + _initialPosition.x)
            {
                transform.localPosition = new Vector3(_goalPosition.x + _initialPosition.x, transform.localPosition.y, 0);
                _door.Unlock();
                Destroy(this);
            }
            else
            {
                transform.localPosition = new Vector3(_initialPosition.x + _currentMouseXDistanceFromOrigin, transform.localPosition.y, 0);    
            }
        }
    }
}
