using System;
using System.Collections;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1.Tinder
{
    public class Mobile_Tinder : MonoBehaviour
    {
        private const String PHONE_BUZZ = "Phone Buzz";

        [SerializeField] private GameObject _zoomMobile;

        private AudioSource _audioSource;
        
        private float _initialZRotation;
        private readonly float _timeToBuzz = 2;
        private float _currentTimeToBuzz;

        private void Start()
        {
            _initialZRotation = transform.localEulerAngles.z;
            _currentTimeToBuzz = 1;
            _audioSource = gameObject.AddComponent<AudioSource>();
            AudioManager.Instance.SetAudioSourceComponent(_audioSource, PHONE_BUZZ);
        }

        private void Update()
        {
            if (_zoomMobile.activeSelf)
            {
                return;
            }
            
            _currentTimeToBuzz -= Time.deltaTime;

            if (_currentTimeToBuzz > 0)
            {
                return;
            }
            StartCoroutine(BuzzMobile());
            _currentTimeToBuzz = _timeToBuzz;
        }

        private IEnumerator BuzzMobile()
        {
            _audioSource.Play();
            float degreesToRotate = 0;

            float maximumRotateDegrees = 15;

            bool rotateToRight = false;
            
            while (maximumRotateDegrees != 0)
            {
                if (degreesToRotate >= maximumRotateDegrees)
                {
                    rotateToRight = false;
                    maximumRotateDegrees--;
                }
                else if (degreesToRotate <= -maximumRotateDegrees)
                {
                    rotateToRight = true;
                    maximumRotateDegrees--;
                }

                if (rotateToRight)
                {
                    degreesToRotate += Time.deltaTime * maximumRotateDegrees * 50;
                }
                else
                {
                    degreesToRotate -= Time.deltaTime * maximumRotateDegrees * 50;
                }

                transform.localRotation = Quaternion.Euler(new Vector3(0, 0, _initialZRotation + degreesToRotate));

                yield return null;
            }
            
            while (Mathf.Abs(_initialZRotation - transform.localEulerAngles.z) < 1)
            {

                if (degreesToRotate <= 0)
                {
                    degreesToRotate += Time.deltaTime * 100;
                }
                else
                {
                    degreesToRotate -= Time.deltaTime * 100;
                }
                
                transform.localRotation = Quaternion.Euler(new Vector3(0, 0, _initialZRotation + degreesToRotate));
                
                yield return null;
            }
            
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, _initialZRotation));
        }
    }
}