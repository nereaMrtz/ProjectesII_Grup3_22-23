using System;
using System.Collections;
using UnityEngine;

namespace Project.Scripts.Levels._1._1._1
{
    public class Button1_1 : MonoBehaviour
    {
        private const String PLAYER_LAYER = "Player";

        [SerializeField] private SpriteRenderer _spriteRenderer;

        [SerializeField] private Animator _animator;
        
        [SerializeField] private Door _door;

        private bool _check;
        
        private float _timeToChangeColor = 0.5f;
        private float _currentTimeToChangeColor;
        private Color _color = new Color(0.84f, 0.84f, 0.84f);
        // Start is called before the first frame update
        
        private void Start()
        {
            _currentTimeToChangeColor = _timeToChangeColor;
            //gameObject.GetComponent<SpriteRenderer>().color = _color;
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (_check)
            {
                return;
            }
            if (collider2D.gameObject.layer != LayerMask.NameToLayer(PLAYER_LAYER))
            {
                return;
            }

            _check = true;
            _door.MoveDoor();
            PressButton();
        }

        private void PressButton() {
            _animator.SetTrigger("Press");
        }
    }
}
