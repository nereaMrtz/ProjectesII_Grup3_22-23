using System;
using System.Collections;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1.NoToques
{
    public class TriggerButton_NoToques : MonoBehaviour
    {
        private const int PLAYER_LAYER = 6;

        private const String ARRASTRAR_BOTON = "ArrastrarBoton(NoToques)";

        [SerializeField] private Transform _playerTransform;

        [SerializeField] private Button_NoToques _button;

        private AudioSource _audioSource;

        private Vector3 _colliderOffset = new Vector3(0, -0.56f, 0);

        private void Start()
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
            AudioManager.Instance.SetAudioSourceComponent(_audioSource, ARRASTRAR_BOTON);
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer == PLAYER_LAYER)
            {
                StartCoroutine(AttractButton());
            }
        }

        private IEnumerator AttractButton()
        {
            _audioSource.Play();
            while (Vector3.Distance(_button.transform.position, _playerTransform.position + _colliderOffset) > 0.1f)
            {
                _button.transform.position = Vector3.MoveTowards(_button.transform.position,
                    _playerTransform.position + _colliderOffset, Time.deltaTime * 15);
                yield return null;
            }
            
            Destroy(gameObject);
        }
    }
}
