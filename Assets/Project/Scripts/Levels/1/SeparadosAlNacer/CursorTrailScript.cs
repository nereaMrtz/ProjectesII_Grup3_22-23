using System;
using UnityEngine;

namespace Project.Scripts.Levels._1.SeparadosAlNacer
{
    public class CursorTrailScript : MonoBehaviour
    {
        [SerializeField] private TrailRenderer _trailRenderer;

        private bool _pressed;
        
        private Vector3 _mousePosition;
        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                _pressed = true;
                _trailRenderer.emitting = true;
                
            }
            else
            {
                _pressed = false;
                _trailRenderer.emitting = false;
            }
            _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(_mousePosition.x, _mousePosition.y, 0);
        }

        public bool GetPressed()
        {
            return _pressed;
        }
    }
}
