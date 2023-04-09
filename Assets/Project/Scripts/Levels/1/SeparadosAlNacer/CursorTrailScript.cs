using System;
using System.Collections;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1.SeparadosAlNacer
{
    public class CursorTrailScript : MonoBehaviour
    {
        private const String DRAW = "Draw";
        
        [SerializeField] private TrailRenderer _trailRenderer;

        [SerializeField] private ElectricityPanel_SeparadosAlNacer _electricityPanel;

        private AudioSource _audioSource;
        
        private Vector3 _mousePosition;

        private Gradient _gradient = new Gradient();

        private GradientColorKey[] _gradientColorKeys = new GradientColorKey[3];

        private GradientColorKey _startGradient = new GradientColorKey(new Color(1,1,1), 0);
        private GradientColorKey _midGradient = new GradientColorKey(new Color(1,1,1), 1);
        private GradientColorKey _endGradient = new GradientColorKey(new Color(1,1,1), 1);

        private bool _pressed;

        private void Start()
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
            AudioManager.Instance.SetAudioSourceComponent(_audioSource, DRAW);
            _gradientColorKeys[0] = _startGradient;
            _gradientColorKeys[1] = _midGradient;
            _gradientColorKeys[2] = _endGradient;
            _gradient.colorKeys = _gradientColorKeys;
            _trailRenderer.colorGradient = _gradient;
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                _audioSource.UnPause();
                _pressed = true;
                _trailRenderer.emitting = true;
            }
            else
            {
                _electricityPanel.SetTime(0);
                _audioSource.Pause();
                _pressed = false;
                _trailRenderer.emitting = false;
            }
            _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(_mousePosition.x, _mousePosition.y, 0);
        }

        public void SetColorTrail()
        {
            _startGradient.color = new Color(1,1,0);
            _gradientColorKeys[0] = _startGradient;
            _gradientColorKeys[1] = _midGradient;
            _gradientColorKeys[2] = _endGradient;
            _gradient.colorKeys = _gradientColorKeys;
            StopAllCoroutines();
            _trailRenderer.colorGradient = _gradient;
            StartCoroutine(DecreaseElectricityPower());
        }

        private IEnumerator DecreaseElectricityPower()
        {
            float timeToDecrease = 1;

            while (timeToDecrease >= 0.5f)
            {
                timeToDecrease -= Time.deltaTime;

                _midGradient.time = timeToDecrease * 2;
                _gradientColorKeys[0] = _startGradient;
                _gradientColorKeys[1] = _midGradient;
                _gradientColorKeys[2] = _endGradient;
                _gradient.colorKeys = _gradientColorKeys;
                _trailRenderer.colorGradient = _gradient;

                yield return null;
            }

            while (timeToDecrease >= 0)
            {
                timeToDecrease -= Time.deltaTime;

                _endGradient.time = timeToDecrease * 2;
                _gradientColorKeys[0] = _startGradient;
                _gradientColorKeys[1] = _midGradient;
                _gradientColorKeys[2] = _endGradient;
                _gradient.colorKeys = _gradientColorKeys;
                _trailRenderer.colorGradient = _gradient;

                yield return null;
            }
            
            _startGradient.color = Color.white;
            _midGradient.color = Color.white;
            _midGradient.time = 1;
            _endGradient.time = 1;
            _gradientColorKeys[0] = _startGradient;
            _gradientColorKeys[1] = _midGradient;
            _gradientColorKeys[2] = _endGradient;
            _gradient.colorKeys = _gradientColorKeys;
            _trailRenderer.colorGradient = _gradient;
        }

        public bool GetPressed()
        {
            return _pressed;
        }
    }
}
