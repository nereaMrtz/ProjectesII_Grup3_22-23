using Project.Scripts.Character;
using UnityEngine;

namespace Project.Scripts.Levels._1.Arrastrate
{
    public class MovementController_Arrastrate : MonoBehaviour
    {
        [SerializeField] private Player _player;
        
        private Vector3 _currentMousePosition;
        private Vector3 _playerOffset;
        private Vector3 _initialMousePosition;
        private void OnMouseDown()
        {
            _initialMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _initialMousePosition.z = 0;
            _playerOffset = _initialMousePosition - transform.position;
        }

        private void OnMouseDrag()
        {
            _currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _currentMousePosition.z = 0;

            if (Vector3.Distance(_currentMousePosition, transform.position + _playerOffset) < 0.1f) 
            {
                _player.SetMovementDirection(Vector2.zero);
                return;
            }
            
            _player.SetMovementDirection(_currentMousePosition - (transform.position + _playerOffset));
        }

        private void OnMouseUp()
        {
            _player.SetMovementDirection(Vector2.zero);
        }
    }
}
