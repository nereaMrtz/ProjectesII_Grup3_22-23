using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Level
{
    public class RoomFadeOut : MonoBehaviour
    {
        private const int PLAYER_LAYER = 6;
        
        [SerializeField] private Image _spriteRenderer;

        [SerializeField] private BoxCollider2D _boxCollider2D;

        private Color _color;

        private float _timerToFadeOut;

        private void Start()
        {
            _spriteRenderer = gameObject.GetComponent<Image>();
            _color = gameObject.GetComponent<SpriteRenderer>().color;
            _timerToFadeOut = 1;
        }

        private IEnumerator FadeOut()
        {
            while (_timerToFadeOut >= 0)
            {
                _timerToFadeOut -= 1 * Time.deltaTime;
                _color.a = _timerToFadeOut;
                _spriteRenderer.color = _color;
                yield return null;
            }
            Destroy(_spriteRenderer);
            Destroy(_boxCollider2D);
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer == PLAYER_LAYER)
            {
                StartCoroutine(FadeOut());
            }
        }
    }
}
