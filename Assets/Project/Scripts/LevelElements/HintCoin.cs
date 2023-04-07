using System;
using System.Collections;
using Project.Scripts.Managers;
using Project.Scripts.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Project.Scripts.LevelElements
{
    public class HintCoin : MonoBehaviour
    {
        private const int PLAYER_LAYER = 6;

        private const String COIN = "Coin";
        private const String COIN_SPRITE_CODE = "<sprite=0>";

        [SerializeField] private SpriteRenderer _spriteRenderer;

        [SerializeField] private InGameUI _inGameUI;
        
        [SerializeField] private Button _button;

        private AudioSource _audioSource;

        private void Start()
        {
            if (GameManager.Instance.IsLevelHintTaken(SceneManager.GetActiveScene().buildIndex))
            {
                Destroy(gameObject);
            }

            GameObject audioGameObject = new GameObject();
            audioGameObject.name = "AudioSource";
            _audioSource = audioGameObject.AddComponent<AudioSource>();
            AudioManager.Instance.SetAudioSourceComponent(_audioSource, COIN);
            audioGameObject.transform.parent = gameObject.transform;
            audioGameObject.transform.localPosition = new Vector3(0.25f, 0.25f, 0);
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            
            if (GameManager.Instance.GetHintCoins() == 0)
            {
                _button.interactable = true;
            }
            _audioSource.Play();
            GameManager.Instance.SetHintCoins(GameManager.Instance.GetHintCoins() + 1);
            GameManager.Instance.SetLevelWhereHintTaken(SceneManager.GetActiveScene().buildIndex);
            _inGameUI.UpdateCoinsMarker();
            _spriteRenderer.enabled = false;
            StartCoroutine(DestroyCoin());
        }

        private IEnumerator DestroyCoin()
        {
            yield return new WaitForSecondsRealtime(_audioSource.clip.length);
            Destroy(gameObject);
        }
    }
}
