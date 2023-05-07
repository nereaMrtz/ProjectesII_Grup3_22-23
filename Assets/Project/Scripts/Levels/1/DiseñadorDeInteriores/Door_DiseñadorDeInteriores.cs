using Project.Scripts.ZoomInForPuzzles.DraggableObject.Movable;
using UnityEngine;

namespace Project.Scripts.Levels._1.DiseñadorDeInteriores
{
    public class Door_DiseñadorDeInteriores : MovableObject
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;

        private new void OnMouseDown()
        {
            base.OnMouseDown();
            RigidbodyConstraints2D constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
            _rigidbody2D.constraints = constraints;
        }

        protected override void Move()
        {
            Vector3 mousePosition = GetMouseWorldCoordinates();
            Vector3 dragPosition = (_initialMousePosition - _currentPosition) + transform.localPosition;
            if (Vector3.Distance(mousePosition, dragPosition) < 0.1f)
            {
                return;
            }
            _rigidbody2D.AddForce((mousePosition - dragPosition).normalized * Time.deltaTime * 60, ForceMode2D.Impulse);
        }

        private void OnMouseUp()
        {
            RigidbodyConstraints2D constraints = RigidbodyConstraints2D.FreezeAll;
            _rigidbody2D.constraints = constraints;
            _rigidbody2D.velocity = Vector2.zero;
        }
    }
}
