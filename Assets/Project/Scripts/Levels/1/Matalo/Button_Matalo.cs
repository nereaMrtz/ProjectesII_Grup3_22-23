using System;
using System.Collections;
using Project.Scripts.Levels._1.Logico;
using Project.Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Levels._1.Matalo
{
    public class Button_Matalo : Button_Logico
    {
        private const String LIGHTS = "Lights";
        
        [SerializeField] private CapsuleCollider2D _capsuleCollider2D;
        [SerializeField] private CapsuleCollider2D _catCapsuleCollider2D;

        [SerializeField] private SpriteRenderer[] _hiddenScenario;

        [SerializeField] private Cat_Matalo _cat;

        [SerializeField] private GameObject _chain;
        [SerializeField] private GameObject _trapFloor;
        [SerializeField] private GameObject _fakeWall;

        [SerializeField] private Image _image;

        private AudioSource _audioSource;

        private float _initialYPositionChain;
        private float _delayTime;

        private int _pressCounter;

        private new void Start()
        {
            base.Start();
            _audioSource = gameObject.AddComponent<AudioSource>();
            AudioManager.Instance.SetAudioSourceComponent(_audioSource, LIGHTS);
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            
            _audioSourcePressButton.Play();
            _animator.SetTrigger("Press");

            switch (_pressCounter)
            {
                case 0:
                    StartCoroutine(GetDownBlanket());
                    StartCoroutine(MoveButton());
                    break;
                
                case 1:
                    StartCoroutine(RemoveBlanket());
                    break;
                
                case 2:
                    StartCoroutine(KillCat());
                    break;
                
                case 3:
                    StartCoroutine(RevealExit());
                    break;
                
                case 4:
                    _door.Unlock();
                    break;
            }

            _pressCounter++;
        }

        private IEnumerator MoveButton()
        {
            while (transform.position.x < 2f)
            {
                transform.position = Vector2.MoveTowards(transform.position,
                    new Vector2(transform.position.x + 2, transform.position.y), Time.deltaTime * 2);

                yield return null;
            }
        }

        private IEnumerator GetDownBlanket()
        {
            _initialYPositionChain = _chain.transform.position.y;
            _capsuleCollider2D.enabled = false;
            while (_chain.transform.position.y > 3.33f)
            {
                _chain.transform.position =
                    Vector2.MoveTowards(_chain.transform.position, new Vector2(_chain.transform.position.x, 3.33f), Time.deltaTime * 3);

                yield return null;
            }

            _capsuleCollider2D.enabled = true;
            _audioSourceReleaseButton.Play();
            _animator.SetTrigger("Press");
            _cat.gameObject.SetActive(true);
        }

        private IEnumerator RemoveBlanket()
        {
            _capsuleCollider2D.enabled = false;
            _catCapsuleCollider2D.enabled = true;
            while (_chain.transform.position.y < _initialYPositionChain)
            {
                _chain.transform.position =
                    Vector2.MoveTowards(_chain.transform.position, new Vector2(_chain.transform.position.x, _initialYPositionChain), Time.deltaTime * 3);

                yield return null;
            }

            _capsuleCollider2D.enabled = true;
            _audioSourceReleaseButton.Play();
            _animator.SetTrigger("Press");
        }

        private IEnumerator KillCat()
        {
            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 1);
            float transitionTime = 2;
            _trapFloor.SetActive(true);
            _audioSource.Play();
            _capsuleCollider2D.enabled = false;
            StartCoroutine(_cat.MyDearCatDieSniffSniff());

            while (transitionTime > 0)
            {
                transitionTime -= Time.deltaTime;

                yield return null;
            }
            
            _cat.gameObject.SetActive(false);
            _audioSource.Play();
            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 0);
            _capsuleCollider2D.enabled = true;
            _animator.SetTrigger("Press");
        }

        private IEnumerator RevealExit()
        {
            float timeToFade = 1;

            while (timeToFade > 0)
            {
                timeToFade -= Time.deltaTime;

                float auxAlpha = ProjectMaths.CustomMath.Map(timeToFade, 1, 0, 0, 1);

                for (int i = 0; i < _hiddenScenario.Length; i++)
                {
                    Color auxColor = _hiddenScenario[i].color;
                    auxColor = new Color(auxColor.r, auxColor.g, auxColor.b, auxAlpha);
                    _hiddenScenario[i].color = auxColor;
                }

                yield return null;
            }
            
            Destroy(_fakeWall);
        }
    }
}
