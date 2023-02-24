using Project.Scripts.NoMonoBehaviourClass;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.NoMonoBehaviourClass
{
    [System.Serializable]
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