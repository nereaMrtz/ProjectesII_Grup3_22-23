using System;
using UnityEngine;

namespace Project.Scripts.NoMonoBehaviourClass {
    
    [Serializable]
    public abstract class PlayerMovement
    {
        protected float _movementX;
        protected float _movementY;

        public abstract Vector2 MovementController();
    }

}