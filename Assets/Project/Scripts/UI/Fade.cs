using Project.Scripts.Managers;
using Project.Scripts.ProjectMaths;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.UI 
{
    public class Fade : MonoBehaviour
    {
        [SerializeField] private Image _image;

        [SerializeField] private float _timeToChange;

        private float _currentTime;

        private Color _auxColor;

        private void OnEnable()
        {
            _image.enabled = true;
            FadeAnimation();
        }

        public void FadeAnimation() {

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

            while (_currentTime > 0)
            {                
                _currentTime -= Time.deltaTime;
                _auxColor.a = CustomMath.Map(_currentTime, _timeToChange, 0, newMin, newMax);
                _image.color = _auxColor;
                
                yield return null;
            }
            GameManager.Instance.SetFading(false);
        }

        public bool IsFinished() {
            return _currentTime < 0;
        }
    }
}