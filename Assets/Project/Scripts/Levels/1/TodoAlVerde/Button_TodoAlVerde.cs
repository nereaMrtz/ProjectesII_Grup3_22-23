using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels.TodoAlVerde 
{
    public class Button_TodoAlVerde : MonoBehaviour
    {
        private const int PLAYER_LAYER = 6;

        private const string PRESS_BUTTON = "RedButton";

        [SerializeField] private Animator _animator;

        [SerializeField] private RuntimeAnimatorController[] _buttonAnimationControllers;

        [SerializeField] private ButtonController_TodoAlVerde _buttonController;

        [SerializeField] private float[] _timeToChange;

        private bool[] _activeButton = new bool[2];

        [SerializeField] private bool _correct;

        [SerializeField] private int _buttonIndex;

        private float _currentTime;

        private int _counter;


        void Start()
        {
            _activeButton[0] = true;
            _currentTime = Random.Range(1, _timeToChange[1]);
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
            AudioManager.Instance.Play(PRESS_BUTTON);

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

            AudioManager.Instance.Play(PRESS_BUTTON);

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