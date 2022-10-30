using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Level
{
    public class Room : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        [SerializeField] private BoxCollider2D _boxCollider2D;

        private Color _color;

        private float _timerToFadeOut;

        private bool _playerEnters;


        private void Start()
        {
            _color = gameObject.GetComponent<SpriteRenderer>().color;
            _timerToFadeOut = 1;
        }

        private void Update()
        {
            if (_playerEnters)
            {
                FadeOut();
            }
        }

        private void FadeOut()
        {
            if (_timerToFadeOut >= 0)
            {
                _timerToFadeOut -= 2 * Time.deltaTime;
                _color.a = _timerToFadeOut;
                gameObject.GetComponent<SpriteRenderer>().color = _color;
            }
            else
            {
                Destroy(_spriteRenderer);
                Destroy(_boxCollider2D);
            }
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer == 6)
            {
                _playerEnters = true;
            }
        }
    }
}
