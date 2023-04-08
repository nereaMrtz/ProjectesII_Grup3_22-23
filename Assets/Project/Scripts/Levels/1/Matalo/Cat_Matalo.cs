using System;
using System.Collections;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1.Matalo
{
    public class Cat_Matalo : MonoBehaviour
    {
        private const String CAT_CRIES = "Cat Cries"; 
        private const String CAT_PURR = "Cat Purr"; 
        
        private AudioSource _audioSourceCatCries;
        private AudioSource _audioSourceCatPurr;

        private void Awake()
        {
            _audioSourceCatCries = gameObject.AddComponent<AudioSource>();
            _audioSourceCatPurr = gameObject.AddComponent<AudioSource>();
            AudioManager.Instance.SetAudioSourceComponent(_audioSourceCatCries, CAT_CRIES);
            AudioManager.Instance.SetAudioSourceComponent(_audioSourceCatPurr, CAT_PURR);
        }

        private void OnEnable()
        {
            _audioSourceCatPurr.Play();
        }

        public IEnumerator MyDearCatDieSniffSniff()
        {
            _audioSourceCatPurr.Stop();

            yield return new WaitForSeconds(0.3f);
            
            _audioSourceCatCries.Play();

        }
    }
}
