using System;
using System.Collections;
using Project.Scripts.Character;
using UnityEngine;

namespace Project.Scripts.Levels._1.NoToques
{
    public class Button_NoToques : MonoBehaviour
    {

        private const String PULSAR_BOTON = "PulsarBoton";
        private const String SOLTAR_BOTON = "SoltarBoton";
        
        [SerializeField] private Player _player;

        [SerializeField] private float _timeToDisappear;

        [SerializeField] private SpriteRenderer _spriteRenderer;

        [SerializeField] private GameObject _boxCollider2D;

        private Color _color;

        private float _currentTime;

        private bool _moved;

        private void Start()
        {
            _currentTime = _timeToDisappear;
            _color = _spriteRenderer.color;
        }

        private void Update()
        {
            _currentTime -= Time.deltaTime;

            if (_player.GetMovement().magnitude != 0)
            {
                _moved = true;
            }

            if (_currentTime<= 0 && !_moved)
            {
                StartCoroutine(Disappear());
            }
        }

        private IEnumerator Disappear()
        {
            float auxAlpha = _color.a;
            
            while (auxAlpha > 0)
            {
                auxAlpha -= Time.deltaTime * 2;
                _spriteRenderer.color = new Color(_color.r, _color.g, _color.b, auxAlpha);
                yield return null;
            }
            
            Destroy(_boxCollider2D);
            Destroy(gameObject);
        }
    }
}
