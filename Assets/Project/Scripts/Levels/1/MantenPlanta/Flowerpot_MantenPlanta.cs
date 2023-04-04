using System;
using Project.Scripts.ZoomInForPuzzles.DraggableObject.Movable;
using Unity.VisualScripting;
using UnityEngine;

namespace Project.Scripts.Levels._1.MantenPlanta
{
    public class Flowerpot_MantenPlanta : MovableObject
    {
        [SerializeField] private CapsuleCollider2D _capsuleCollider2D;

        [SerializeField] private Button_MantenPlanta _button;
        
        private Vector3 _targetPosition;

        [SerializeField] private bool _correctPlace;

        private void OnMouseDown()
        {
            _capsuleCollider2D.enabled = false;
        }

        protected override void Move()
        {
            _targetPosition = GetMouseWorldCoordinates();

            Vector3 nextPosition = Vector2.MoveTowards(transform.position, _targetPosition, Time.deltaTime * 10);
            
            if (nextPosition.x < -5.34f || nextPosition.x > 4.9f || nextPosition.y < -2.72f || nextPosition.y > 1.5f)
            {
                return;
            }

            transform.position = nextPosition;
        }

        private void OnMouseUp()
        {
            _capsuleCollider2D.enabled = true;
            if (_correctPlace)
            {
                _button.AnchorThePot();
            }
        }

        public void SetCorrectPlace(bool correctPlace)
        {
            _correctPlace = correctPlace;
        }
    }
}
