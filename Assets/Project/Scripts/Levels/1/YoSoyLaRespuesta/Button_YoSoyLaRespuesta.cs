using Project.Scripts.Levels._1.TodoAlVerde;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1.YoSoyLaRespuesta
{
    public class Button_YoSoyLaRespuesta : MonoBehaviour
    {
        private const int PLAYER_LAYER = 6;

        private const string PRESS_BUTTON = "Press Button";
        private const string RELEASE_BUTTON = "Release Button";

        [SerializeField] private Animator _animator;

        [SerializeField] private RuntimeAnimatorController[] _buttonAnimationControllers;

        [SerializeField] private ButtonController_TodoAlVerde _buttonController;

        [SerializeField] private float[] _timeToChange;

        [SerializeField] private bool _correct;

        [SerializeField] private int _buttonIndex;

        [SerializeField] private float _currentTime;
    
        private AudioSource _audioSourcePressButton;
        private AudioSource _audioSourceReleaseButton;

        private bool[] _activeButton = new bool[9];

        private int _counter;

        void Start()
        {
            _activeButton[0] = true;
            _currentTime = Random.Range(1, _timeToChange[1]);
            AudioManager.Instance.SetAudioSourceComponent(_audioSourcePressButton, PRESS_BUTTON);
            AudioManager.Instance.SetAudioSourceComponent(_audioSourceReleaseButton, RELEASE_BUTTON);
        }


        void Update()
        {
            if (_correct)
            {
                return;
            }

            _currentTime -= Time.deltaTime;

            if (_currentTime <= 0)
            {
                if (_counter == 0)
                {
                    _currentTime = _timeToChange[_counter];
                }
                else
                {
                    _currentTime = Random.Range(1, _timeToChange[_counter]);
                }
                _activeButton[_counter] = false;
                _counter = (_counter + 1) % 10;
                _activeButton[_counter] = true;
                _animator.runtimeAnimatorController = _buttonAnimationControllers[_counter];
            }
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }

            _animator.SetTrigger("Press");

            if (!_activeButton[1])
            {
                _buttonController.SetFalseToAllButtons();
                _correct = false;
                return;
            }
        
            _audioSourcePressButton.Play();

            _buttonController.SetCorrectButton(_buttonIndex);
            _correct = true;
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {

            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }

            _animator.SetTrigger("Press");
            _audioSourceReleaseButton.Play();
        }

        public void SetCorrectFalse()
        {
            _correct = false;
        }
    }
}