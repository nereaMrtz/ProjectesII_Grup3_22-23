using System;
using System.Collections;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1.Tinder
{
    public class Mobile_Tinder : MonoBehaviour
    {
        private const String MOBILE_BUZZ = "Mobile Buzz";

        private AudioSource _audioSource;
        
        private float _initialZRotation;
        private readonly float _timeToBuzz = 2;
        private float _currentTimeToBuzz;

        private void Start()
        {
            _initialZRotation = transform.localEulerAngles.z;
            _currentTimeToBuzz = 1;
            _audioSource = gameObject.AddComponent<AudioSource>();
            //AudioManager.Instance.SetAudioSourceComponent(_audioSource, MOBILE_BUZZ);
        }

        private void Update()
        {
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