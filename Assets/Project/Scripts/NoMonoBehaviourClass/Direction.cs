using System;
using UnityEngine;

namespace Project.Scripts.NoMonoBehaviourClass
{
    [Serializable]
    public class Direction
    {
        private enum CardinalDirection { UP, DOWN, LEFT, RIGHT }

        [SerializeField] private CardinalDirection _direction;
        [SerializeField] private int _steps;

        public Vector3 GetVector()
        {
            Vector3 vector = new Vector3();
            
            switch(_direction)
            {
                case CardinalDirection.UP:
                    vector = Vector3.up;
                    break;
                case CardinalDirection.DOWN:
                    vector = Vector3.down;
                    break;
                case CardinalDirection.LEFT:
                    vector = Vector3.left;
                    break;
                case CardinalDirection.RIGHT:
                    vector = Vector3.right;
                    break;
            }

            return vector * _steps;
        }
    }

}
