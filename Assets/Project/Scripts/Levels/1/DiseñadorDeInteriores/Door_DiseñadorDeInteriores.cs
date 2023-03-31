using UnityEngine;

namespace Project.Scripts.Levels._1.DiseñadorDeInteriores
{
    public class Door_DiseñadorDeInteriores : MonoBehaviour
    {
        [SerializeField] private Button_DiseñadorDeInteriores _button;

        [SerializeField] private SpriteRenderer _spriteRenderer;

        private Vector3 _offset;

        private Vector3 _teleportButtonPosition;

        private bool _clicked;

        private void Start()
        {
            _offset = new Vector3(_spriteRenderer.size.x / 2, _spriteRenderer.size.y / 2);
            _teleportButtonPosition =
                new Vector3(transform.position.x + _offset.x, transform.position.y, transform.position.y);
        }

        private void OnMouseDown()
        {
            if (_button.GetClicked())
            {
                (transform.position, _button.transform.position) = (_button.transform.position - _offset, _teleportButtonPosition);
                Destroy(this);
            }

            _clicked = true;
        }

        public Vector3 GetOffset()
        {
            return _offset;
        }

        public Vector3 GetTeleportButtonPosition()
        {
            return _teleportButtonPosition;
        }

        public bool GetClicked()
        {
            return _clicked;
        }
    }
}
