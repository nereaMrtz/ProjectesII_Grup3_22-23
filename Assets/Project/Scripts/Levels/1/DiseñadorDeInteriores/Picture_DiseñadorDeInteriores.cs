using Project.Scripts.ZoomInForPuzzles.DraggableObject.Movable;
using UnityEngine;

namespace Project.Scripts.Levels._1.DiseñadorDeInteriores
{
    public class Picture_DiseñadorDeInteriores : MovableObject
    {
        private float _currentMouseXDistanceFromOrigin;

        [SerializeField] private bool _goRight;

        protected override void Move()
        {
            _currentMouseXDistanceFromOrigin = (_currentMousePosition.x - _initialMousePosition.x) + (_currentPosition.x - _initialPosition.x);

            if (_goRight)
            {
                if (transform.localPosition.x + _currentMouseXDistanceFromOrigin < _initialPosition.x ||
                    _initialPosition.x + _currentMouseXDistanceFromOrigin >= _goalPosition.x + _initialPosition.x)
                {
                    return;
                }
            }
            else
            {
                if (transform.localPosition.x + _currentMouseXDistanceFromOrigin > _initialPosition.x ||
                    _initialPosition.x + _currentMouseXDistanceFromOrigin <= _goalPosition.x + _initialPosition.x)
                {
                    return;
                }
            }
            transform.localPosition = new Vector3(_initialPosition.x + _currentMouseXDistanceFromOrigin, transform.localPosition.y, 0);   
        }
    }
}
