using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Levels.TodoAlVerde 
{
    public class Button_TodoAlVerde : MonoBehaviour
    {
        private const int PLAYER_LAYER = 6;

        [SerializeField] private Animator _animator;

        [SerializeField] private RuntimeAnimatorController[] _buttonControllers;

        [SerializeField] private float[] _timeToChange;

        private bool[] _activeButton = new bool[2];

        [SerializeField] private bool _correct;

        private float _currentTime;

        private int _counter;

        // Start is called before the first frame update
        void Start()
        {
            _activeButton[0] = true;
            _currentTime = _timeToChange[1];
        }

        // Update is called once per frame
        void Update()
        {
            _currentTime -= Time.deltaTime;

            if (_currentTime <= 0)
            {
                _animator.runtimeAnimatorController = _buttonControllers[_counter];
                _currentTime = _timeToChange[_counter];
                _activeButton[_counter] = false;                
                _counter = (_counter + 1) % 2;
                _activeButton[_counter] = true;
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
                _correct = false;
                return;
            }
            _correct = true;
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {

            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }

            _animator.SetTrigger("Press");
        }
    }

}