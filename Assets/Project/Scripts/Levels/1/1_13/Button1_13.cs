using Project.Scripts.Levels._1._1_1;
using UnityEngine;

namespace Project.Scripts.Levels._1._1_13
{
    public class Button1_13 : Button1_1
    {
        private const int PLAYER_LAYER = 6;

        [SerializeField] private float _timeToOpenDoor;

        [SerializeField] private Door1_13 _door1_13;

        private float _currentTime;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            ButtonAction();
            _door1_13.AnimatorStep(_pressed);
            _currentTime = Time.time;
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            ButtonAction();
            if (Time.time - _currentTime > _timeToOpenDoor && !_door1_13.IsUnlocked())
            {
                _door1_13.Unlock();
            }
            _door1_13.AnimatorStep(_pressed);
            _currentTime = 0;
        }
    }
}
