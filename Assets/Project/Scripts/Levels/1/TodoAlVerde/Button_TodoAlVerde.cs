using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1.TodoAlVerde 
{
    public class Button_TodoAlVerde : MonoBehaviour
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
        
        private AudioSource _audioSourcePressButton;
        private AudioSource _audioSourceReleaseButton;

        private bool[] _activeButton = new bool[2];

        private float _currentTime;

        private int _counter;


        void Start()
        {
            _activeButton[0] = true;
            _currentTime = Random.Range(1, _timeToChange[1]);
            _audioSourcePressButton = gameObject.AddComponent<AudioSource>();
            _audioSourceReleaseButton = gameObject.AddComponent<AudioSource>();
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
                _counter = (_counter + 1) % 2;
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
            _audioSourcePressButton.Play();

            if (!_activeButton[1])
            {
                _buttonController.SetFalseToAllButtons();
                return;
            }

            _buttonController.SetCorrectButton(_buttonIndex);
            _correct = true;
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {

            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }

            _audioSourceReleaseButton.Play();

            _animator.SetTrigger("Press");
        }

        public void SetCorrectFalse()
        {
            _correct = false;
        }

        /*beatproximity: closer to 0 = closer to beat;
        beatproximity: closer to 1 = further from beat;
        float adjustedSongTime = AudioSource.time - songOffset;
        float beatTime = BPM / 60f;
        float beatProximity = Mathf.Sqrt(Mathf.Abs(Mathf.Sin(Mathf.Deg2Rad* (90f + 180f * (AdjustedSongTime / beatTime)))));
        float currentBeat = adjustedSongTime / beatTime;*/
    }
}