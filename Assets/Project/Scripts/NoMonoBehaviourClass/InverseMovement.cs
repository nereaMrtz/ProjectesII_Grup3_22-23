using System;
using UnityEngine;

namespace Project.Scripts.NoMonoBehaviourClass
{
    [Serializable]
    public class InverseMovement : PlayerMovement
    {
        public override Vector2 MovementController()
        {
            if (Input.GetKey(KeyCode.A))
            {
                _movementX += 1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                _movementX += -1;
            }
            if (Input.GetKey(KeyCode.W))
            {
                _movementY += -1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                _movementY += 1;
            }

            return new Vector2(_movementX, _movementY).normalized;
        }
    }
}