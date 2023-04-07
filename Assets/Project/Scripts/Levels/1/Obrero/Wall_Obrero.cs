using System;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1.Obrero
{
    public class Wall_Obrero : MonoBehaviour
    {
        private const int PLAYER_LAYER = 6;

        private const String HIW_WALL = "ChocarParedes";
        
        private int _hitsToBreak = 2;

        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
            AudioManager.Instance.SetAudioSourceComponent(_audioSource, HIW_WALL);
        }

        private void OnCollisionEnter2D(Collision2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }

            _audioSource.Play();
            _hitsToBreak--;

            if (_hitsToBreak == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
