using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Puzzle.CrossCardinalDirections
{
    public class PressurePoint : MonoBehaviour
    {
        private const String PLAYER_LAYER = "Player";

        [SerializeField] private SpriteRenderer _spriteRenderer;

        private CrossCardinalDirectionsPuzzle _crossCardinalDirectionsPuzzle;

        private bool _check;

        private bool _back;

        private float _timeToChangeColor = 0.5f;
        private float _currentTimeToChangeColor;
        private Color _color = new Color(0.84f, 0.84f, 0.84f);

        private void Start()
        {
            _currentTimeToChangeColor = _timeToChangeColor;
            gameObject.GetComponent<SpriteRenderer>().color = _color;
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer == LayerMask.NameToLayer(PLAYER_LAYER))
            {
                if (_check)
                {
                    SetBack(true);
                }
                else
                {
                    SetCheck(true);    
                }
            }
        }

        public IEnumerator ChangeColor(Color color)
        {
            bool exit = false;
            
            while (!exit)
            {
                if (_spriteRenderer.color == color)
                {
                    _currentTimeToChangeColor = _timeToChangeColor;
                    exit = true;
                }
                else
                {
                    _spriteRenderer.color = Color.Lerp(_spriteRenderer.color, color,
                        Time.deltaTime / _currentTimeToChangeColor);
                    _currentTimeToChangeColor -= Time.deltaTime;
                }

                yield return null;
            }
        }

        public bool IsChecked()
        {
            return _check;
        }

        public void SetCheck(bool check)
        {
            _check = check;
        }

        public bool IsBack()
        {
            return _back;
        }

        public void SetBack(bool back)
        {
            _back = back;
        }

        public Color GetColor()
        {
            return _color;
        }
    }
}