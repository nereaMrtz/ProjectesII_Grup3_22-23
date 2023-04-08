using System;
using System.Collections;
using Project.Scripts.Managers;
using TMPro;
using UnityEngine;

namespace Project.Scripts.Levels._1.Notob
{
    public class Controller_Notob : MonoBehaviour
    {
        private const String DISCOVERY = "Discovery";
        
        [SerializeField] private Letter_Notob[] _letters;

        [SerializeField] private TextMeshProUGUI[] _lettersImage;

        [SerializeField] private GameObject _button;

        [SerializeField] private SpriteRenderer _buttonSpriteRenderer;

        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
            AudioManager.Instance.SetAudioSourceComponent(_audioSource, DISCOVERY);
        }

        public void CheckOrder() 
        {
            for (int i = 0; i < _letters.Length - 1; i++)
            {
                if (!(Vector3.Distance(_letters[i].transform.position, _letters[i + 1].transform.position) < 1.0f &&
                    Mathf.Abs(Vector3.Angle(_letters[i + 1].transform.position - _letters[i].transform.position, Vector3.right)) < 15.0f))
                {
                    return;
                }
            }
            _audioSource.Play();
            _button.SetActive(true);
            StartCoroutine(FadeInButton());
            for (int i = 0; i < _letters.Length; i++)
            {
                StartCoroutine(FadeOutLetter(_lettersImage[i], i));
            }
        }

        private IEnumerator FadeOutLetter(TextMeshProUGUI image, int index)
        {
            Color color = image.color;
            
            float auxAlpha = color.a;
            
            while (auxAlpha > 0f)
            {
                auxAlpha -= Time.deltaTime;
                image.color = new Color(color.r, color.g, color.b, auxAlpha);
                yield return null;
            }
            
            Destroy(_letters[index].gameObject);
        }

        private IEnumerator FadeInButton()
        {
            Color color = _buttonSpriteRenderer.color;
            
            float auxAlpha = color.a;
            
            while (auxAlpha < 1f)
            {
                auxAlpha += Time.deltaTime;
                _buttonSpriteRenderer.color = new Color(color.r, color.g, color.b, auxAlpha);
                yield return null;
            }
        }
    }
}
