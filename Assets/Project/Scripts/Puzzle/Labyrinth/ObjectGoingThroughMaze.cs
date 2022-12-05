using System.Collections;
using UnityEngine;

namespace Project.Scripts.Puzzle.Labyrinth
{
    public class ObjectGoingThroughMaze : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;

        [SerializeField] private Vector3 _initialPosition;
        [SerializeField] private Vector3 _targetPosition;

        [SerializeField] private float _speed;

        private Vector3 _movementDirection;

        private float _velocityY;
        private float _velocityX;
        
        // Update is called once per frame
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
            return transform.position == _targetPosition;
        }

        private void Controls()
        {
            if (Input.GetKey(KeyCode.W))
            {
                _velocityY = 1;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                _velocityX = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                _velocityX = 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                _velocityY = -1;
            }
            else
            {
                _velocityX = 0;
                _velocityY = 0;
            }
        }        

        private void MoveObject()
        {
            _movementDirection = new Vector3(_velocityX, _velocityY).normalized;
            _rigidbody2D.AddForce(_movementDirection * _speed, ForceMode2D.Force);            
        }
    }
}
