using System;
using System.Collections;
using Project.Scripts.Managers;
using Project.Scripts.ProjectMaths;
using Project.Scripts.Sound;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Character
{
    public class DrugEffect : MonoBehaviour
    {
        private const String THROW_UP_SOUND_CLIP_NAME = "Throw Up Sound";
        private const String TAKE_THIS_PILL_SOUND_CLIP_NAME = "Take This Pill Sound";

        [SerializeField] private Image _changeStateEffect;

        [SerializeField] private Image _filter;

        [SerializeField] private GameObject _throwUpPrefab;

        private GameObject _throwUp;
        
        private bool _canChangeState = true;
        private bool _betweenChangePeriod;

        private void Start()
        {
            _throwUp = Instantiate(_throwUpPrefab);
            _throwUp.SetActive(false);
        }

        public void ChangeState(AudioManager audioManager)
        {
            if (_canChangeState)
            {
                if (GameManager.Instance.IsDrugged())
                {
                    audioManager.Play(THROW_UP_SOUND_CLIP_NAME);
                    StartCoroutine(ChangeStateEffect(audioManager.ClipDuration(THROW_UP_SOUND_CLIP_NAME), true));
                }
                else
                {
                    audioManager.Play(TAKE_THIS_PILL_SOUND_CLIP_NAME);
                    StartCoroutine(ChangeStateEffect(audioManager.ClipDuration(TAKE_THIS_PILL_SOUND_CLIP_NAME), false));
                }
                GameManager.Instance.SetDrugged(!GameManager.Instance.IsDrugged()); 
            }
        }

        public void SetCanChangeState(bool canChangeState)
        {
            _canChangeState = canChangeState;
        }

        public bool GetCanChangeState()
        {
            return _canChangeState;
        }
        
        private IEnumerator ChangeStateEffect(float time, bool drugged)
        {
            float currentTime = time;
            Color alpha = _changeStateEffect.color;
            _betweenChangePeriod = true;
            while (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                if (currentTime > time - time / 4)
                {
                    alpha.a = CustomMath.Map(currentTime, time - time / 4, time, 1, 0);
                }
                else if (currentTime < time / 4)
                {
                    if (drugged)
                    {
                        _throwUp.gameObject.transform.position = gameObject.transform.position + new Vector3(0, -0.215f * 2,0); 
                        _throwUp.SetActive(true);
                        drugged = false;
                    }
                    alpha.a = CustomMath.Map(currentTime, 0, time / 4, 0, 1);
                }
                else
                {
                    if (GameManager.Instance.IsDrugged())
                    {
                        _filter.color = new Color(0.64f, 0, 0.33f, 0.23f);
                    }
                    else
                    {
                        _filter.color = new Color(0.64f, 0, 0.33f, 0);
                    }
                    alpha.a = 1;
                }
                _changeStateEffect.color = new Color(alpha.r, alpha.g, alpha.b, alpha.a);
                yield return null;
            }
            _betweenChangePeriod = false;
        }

        public bool GetBetweenChangePeriod()
        {
            return _betweenChangePeriod;
        }
    }
}