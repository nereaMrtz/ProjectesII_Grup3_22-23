using System;
using System.Collections;
using Project.Scripts.Interactable.Static;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1.TocToc
{
    public class Door_TocToc : MonoBehaviour
    {
        private const String TOC = "Toc";
        protected const String SIMPLE_DOOR_SOUND = "Simple Door Sound";
        
        [SerializeField] private UnlockableObject _door;

        [SerializeField] private BoxCollider2D _boxCollider2D;
        
        private AudioSource _audioSourceToc;
        private AudioSource _audioSourceOpenDoor;

        private int _timesKnocked;

        private void Start()
        {
            _audioSourceToc = gameObject.AddComponent<AudioSource>();
            _audioSourceOpenDoor = gameObject.AddComponent<AudioSource>();
            AudioManager.Instance.SetAudioSourceComponent(_audioSourceToc, TOC);
            AudioManager.Instance.SetAudioSourceComponent(_audioSourceOpenDoor, SIMPLE_DOOR_SOUND);
        }

        private void OnMouseDown()
        {
            if (_door.IsUnlocked())
            {
                return;
            }
            _audioSourceToc.Play();
            _timesKnocked++;
            if (_timesKnocked == 1)
            {
                StartCoroutine(ResetKnockKnock());
            }
            else
            {
                StopAllCoroutines();
                _audioSourceOpenDoor.Play();
                _door.Unlock();
                Destroy(_boxCollider2D);
            }
        }

        private IEnumerator ResetKnockKnock()
        {
            yield return new WaitForSeconds(1);
            _timesKnocked = 0;
        }
    }
}
