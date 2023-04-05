using Project.Scripts.Character;
using Project.Scripts.Levels._1.Logico;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.Levels._1.Semaforo
{
    public class Button_Semaforo : Button_Logico
    {
        [SerializeField] private Player _player;
        
        [SerializeField] private RuntimeAnimatorController[] _animatorControllers;

        private float _timeToChange = 0.75f;
        private float _currentTimeToChange;

        [SerializeField] private int _currentAnimatorControllerIndex;

        private void Start()
        {
            _currentTimeToChange = _timeToChange;
        }

        private void Update()
        {
            _currentTimeToChange -= Time.deltaTime;
            
            if (_currentTimeToChange <= 0.0f)
            {
                _currentAnimatorControllerIndex = (_currentAnimatorControllerIndex + 1) % _animatorControllers.Length;
                _animator.runtimeAnimatorController = _animatorControllers[_currentAnimatorControllerIndex];
                _currentTimeToChange = _timeToChange;
            }
            
            
            if (_player.GetMovement() == Vector2.zero)
            {
                return;
            }
            
            if (_currentAnimatorControllerIndex == _animatorControllers.Length - 1)
            {
                return;
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
