using System;
using System.Collections;
using Project.Scripts.Managers;
using Project.Scripts.ProjectMaths;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.UI 
{
    public class Fade : MonoBehaviour
    {
        private const string FADE = "Fade";
        private const string REVERSE_FADE = "Reverse Fade";
        
        [SerializeField] private Image _image;

        private AudioSource _audioSourceFade;
        private AudioSource _audioSourceReverseFade;

        private float _timeToChange;
        
        private float _currentTime;

        private void Awake()
        {
            _audioSourceFade = gameObject.AddComponent<AudioSource>();
            _audioSourceReverseFade = gameObject.AddComponent<AudioSource>();
            AudioManager.Instance.SetAudioSourceComponent(_audioSourceFade, FADE);
            AudioManager.Instance.SetAudioSourceComponent(_audioSourceReverseFade, REVERSE_FADE);
            _timeToChange = _audioSourceFade.clip.length;
        }

        private void OnEnable()
        {
            _image.enabled = true;
            FadeAnimation(false);
        }

        public void FadeAnimation(bool reverseFade) {

            if (reverseFade)
            {
                _audioSourceReverseFade.Play();
            }
            else
            {
                _audioSourceFade.Play();    
            }
            
            _currentTime = _timeToChange;

            if (_image.color.a == 1)
            {   
                StartCoroutine(FadeAction(1, 0));
            }
            else 
            {                
                StartCoroutine(FadeAction(0, 1));
            }

        }

        private IEnumerator FadeAction(int newMin, int newMax) {

            GameManager.Instance.SetFading(true);

            Color auxColor = new Color();

            while (_currentTime > 0)
            {                
                _currentTime -= Time.deltaTime;
                auxColor.a = CustomMath.Map(_currentTime, _timeToChange, 0, newMin, newMax);
                _image.color = auxColor;
                
                yield return null;
            }
            GameManager.Instance.SetFading(false);
        }

        public bool IsFinished() {
            return _currentTime <= 0;
        }
    }
}