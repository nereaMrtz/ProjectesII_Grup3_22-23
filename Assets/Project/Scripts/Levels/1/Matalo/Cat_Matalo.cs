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
        private const String GATE_OPENING = "Gate Opening"; 
        
        private AudioSource _audioSourceCatCries;
        private AudioSource _audioSourceCatPurr;
        private AudioSource _audioSourceGate;

        private void Awake()
        {
            _audioSourceCatCries = gameObject.AddComponent<AudioSource>();
            _audioSourceCatPurr = gameObject.AddComponent<AudioSource>();
            _audioSourceGate = gameObject.AddComponent<AudioSource>();
            AudioManager.Instance.SetAudioSourceComponent(_audioSourceCatCries, CAT_CRIES);
            AudioManager.Instance.SetAudioSourceComponent(_audioSourceCatPurr, CAT_PURR);
            AudioManager.Instance.SetAudioSourceComponent(_audioSourceGate, GATE_OPENING);
        }

        private void OnEnable()
        {
            _audioSourceCatPurr.Play();
        }

        public IEnumerator MyDearCatDieSniffSniff()
        {
            _audioSourceCatPurr.Stop();
            _audioSourceGate.Play();

            yield return new WaitForSeconds(1f);
            
            _audioSourceCatCries.Play();

        }
    }
}
