using System;
using Project.Scripts.Levels._1.Manten;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.Levels._1.ComoUnHuevo
{
    public class Button_ComoUnHuevo : MonoBehaviour
    {
        private const int PLAYER_LAYER = 6;
        
        [SerializeField] private Door_Manten _door;

        [SerializeField] private float _timeToHold;

        [SerializeField] private Animator _animator;

        [SerializeField] private float _currentTimeToHold;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            _animator.SetTrigger("Press");
            _currentTimeToHold = _timeToHold;
            _door.AnimatorStep(true);
            
        }

        private void OnTriggerStay2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }

            _currentTimeToHold -= Time.deltaTime;

            if (_currentTimeToHold <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            _currentTimeToHold = _timeToHold;
            _door.AnimatorStep(false);
            _door.ChangePolygonCollider(0);
        }
    }
}
