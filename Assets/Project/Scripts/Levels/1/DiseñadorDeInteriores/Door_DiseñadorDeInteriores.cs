using System;
using UnityEngine;

namespace Project.Scripts.Levels._1.DiseñadorDeInteriores
{
    public class Door_DiseñadorDeInteriores : MonoBehaviour
    {
        [SerializeField] private Controller_DiseñadorDeInteriores _controller;

        [SerializeField] private SpriteRenderer _spriteRenderer;

        private Vector3 _offset;

        [SerializeField] private bool _justClicked;

        private void Awake()
        {
            _offset = new Vector3(_spriteRenderer.size.x / 2, _spriteRenderer.size.y / 2);
        }

        private void OnMouseDown()
        {
            _controller.SetClickedOnDoorTrue();
            _justClicked = true;
        }

        public Vector3 GetOffset()
        {
            return _offset;
        }

        public bool IsJustClicked()
        {
            return _justClicked;
        }

        public void DenyClick()
        {
            _justClicked = false;
        }
    }
}
