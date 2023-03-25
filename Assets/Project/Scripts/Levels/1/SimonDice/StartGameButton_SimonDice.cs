using System.Collections;
using UnityEngine;

namespace Project.Scripts.Levels._1.SimonDice
{
    public class StartGameButton_SimonDice : MonoBehaviour
    {

        private const int PLAYER_LAYER = 6;
        
        [SerializeField] private Controller_SimonDice _controllerSimonDice;
       
        [SerializeField] private SpriteRenderer _spriteRenderer;

        [SerializeField] private Animator _animator;

        private bool _press;

        private void OnEnable()
        {
            StartCoroutine(FadeInButton());
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            _animator.SetTrigger("Press");
            if (_press)
            {
                return;
            }
            _press = true;
            _controllerSimonDice.StartGame();
            StartCoroutine(FadeOutButton());
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            _animator.SetTrigger("Press");
        }

        private IEnumerator FadeOutButton()
        {
            Color color = _spriteRenderer.color;
            
            float auxAlpha = color.a;
            
            while (auxAlpha > 0f)
            {
                auxAlpha -= Time.deltaTime;
                _spriteRenderer.color = new Color(color.r, color.g, color.b, auxAlpha);
                yield return null;
            }
            gameObject.SetActive(false);
        }
        
        private IEnumerator FadeInButton()
        {
            Color color = _spriteRenderer.color;
            
            float auxAlpha = color.a;
            
            while (auxAlpha < 1f)
            {
                auxAlpha += Time.deltaTime;
                _spriteRenderer.color = new Color(color.r, color.g, color.b, auxAlpha);
                yield return null;
            }
            _press = false;
        }
    }
}
