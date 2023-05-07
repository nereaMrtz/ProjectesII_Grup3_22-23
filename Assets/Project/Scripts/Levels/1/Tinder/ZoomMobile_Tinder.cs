using Project.Scripts.Levels._1._1_1;
using Project.Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Levels._1.Tinder
{
    public class ZoomMobile_Tinder : MonoBehaviour
    {
        [SerializeField] private Mobile_Tinder _mobile;
        
        [SerializeField] private Image _image;

        [SerializeField] private Sprite[] _sprites;

        [SerializeField] private Animator _mobileAnimator;

        [SerializeField] private Door _door;

        private GameObject _mobileGameObject;

        private int _currentIndex;

        private void Start()
        {
            _mobileGameObject = _mobile.gameObject;
        }

        private void OnEnable()
        {
            _mobile.transform.localRotation = Quaternion.Euler(0,0,270);
        }

        public void UnPauseGame()
        {
            GameManager.Instance.SetPause(false);
        }

        public void ShowNextMatch()
        {
            if (_currentIndex == _sprites.Length)
            {
                UnPauseGame();
                gameObject.SetActive(false);
                Destroy(_mobile);
                Destroy(_mobileAnimator);
                _mobileGameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 270));
                _door.Unlock();
                return;
            }
            _image.sprite = _sprites[_currentIndex];
            _currentIndex++;
        }
    }
}
