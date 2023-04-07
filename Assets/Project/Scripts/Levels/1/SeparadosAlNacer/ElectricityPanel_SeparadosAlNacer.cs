using System;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1.SeparadosAlNacer
{
    public class ElectricityPanel_SeparadosAlNacer : MonoBehaviour
    {
        private const String ELECTRICITY_PANEL = "Electricity Panel";

        [SerializeField] private CursorTrailScript _cursorTrail;
        
        private float _timeWhenClick;

        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
            AudioManager.Instance.SetAudioSourceComponent(_audioSource, ELECTRICITY_PANEL);
        }

        private void OnMouseEnter()
        {
            if (!Input.GetMouseButton(0))
            {
                return;
            }
            _timeWhenClick = Time.time;
        }

        private void OnMouseDown()
        {
            _audioSource.Play();
            _timeWhenClick = Time.time;
            _cursorTrail.SetColorTrail();
        }

        public float GetTime()
        {
            return _timeWhenClick;
        }

        public void SetTime(float time)
        {
            _timeWhenClick = time;
        }
    }
}
