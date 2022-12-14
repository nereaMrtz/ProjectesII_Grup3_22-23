using System.Collections;
using UnityEngine;

namespace Project.Scripts.Puzzle.Labyrinth
{
    public class ObjectGoingThroughMaze : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;

        [SerializeField] private Vector3 _targetPosition;

        [SerializeField] private float _speed;
        [SerializeField] private float _range;

        private Vector3 _movementDirection;

        private float _velocityY;
        private float _velocityX;
        
        void Update()
        {
            Controls();
        }

        private void FixedUpdate()
        {
            MoveObject();
        }

        public bool CheckEndCell()
        {
            return Vector3.Distance(transform.localPosition, _targetPosition) < _range;
        }

        private void Controls()
        {
            if (Input.GetKey(KeyCode.W))
            {
                _velocityY = _speed;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                _velocityY = -_speed;
            }
            else
            {
                _velocityY = 0;
            }
            
            if (Input.GetKey(KeyCode.A))
            {
                _velocityX = -_speed;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                _velocityX = _speed;
            }
            else
            {
                _velocityX = 0;
            }
        }        

        private void MoveObject()
        {
            _rigidbody2D.velocity = new Vector2(_velocityX, _velocityY);        
        }
    }
}
