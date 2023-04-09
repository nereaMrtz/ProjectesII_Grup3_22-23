using System;
using System.Collections;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1.Obrero
{
    public class Wall_Obrero : MonoBehaviour
    {
        private const int PLAYER_LAYER = 6;

        private const String HIW_WALL = "ChocarParedes";
        private const String DESTROY_WALL = "Destroy Wall";

        [SerializeField] private Player_Obrero _playerObrero;

        [SerializeField] private BoxCollider2D _boxCollider2D;

        [SerializeField] private SpriteRenderer _spriteRenderer;

        [SerializeField] private Sprite _finalCrash;

        [SerializeField] private GameObject _oscuro;

        private AudioSource _audioSourceHit;
        private AudioSource _audioSourceDestroy;
        
        private int _hitsToBreak = 2;

        private void Start()
        {
            _audioSourceHit = gameObject.AddComponent<AudioSource>();
            _audioSourceDestroy = gameObject.AddComponent<AudioSource>();
            AudioManager.Instance.SetAudioSourceComponent(_audioSourceHit, HIW_WALL);
            AudioManager.Instance.SetAudioSourceComponent(_audioSourceDestroy, DESTROY_WALL);
        }

        private void OnCollisionEnter2D(Collision2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }

            if (!_playerObrero.HasHammer())
            {
                return;
            }

            _spriteRenderer.sprite = _finalCrash;
            _hitsToBreak--;

            if (_hitsToBreak == 0)
            {
                _audioSourceDestroy.Play();
                _boxCollider2D.enabled = false;
                _spriteRenderer.enabled = false;
                StartCoroutine(DestroyWall());
                return;
            }
            _audioSourceHit.Play();
        }

        private IEnumerator DestroyWall()
        {
            _oscuro.SetActive(false);
            yield return new WaitForSecondsRealtime(_audioSourceDestroy.clip.length);
            Destroy(gameObject); 

        }
    }
}
