using Project.Scripts.Levels._1._1_1;
using UnityEngine;

namespace Project.Scripts.Levels._1._1_13
{
    public class Button1_13 : Button1_1
    {
        private float _currentTime;
        [SerializeField] private float _timeToOpenDoor;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != 6)
            {
                return;
            }
            ButtonAction();
        }

        private void OnTriggerStay2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != 6)
            {
                return;
            }

            _currentTime += Time.deltaTime;

            if (!(_currentTime >= _timeToOpenDoor))
            {
                return;
            }
            if (_door.IsUnlocked())
            {
                return;
            }
            _door.Unlock();
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != 6)
            {
                return;
            }
            ButtonAction();
            _currentTime = 0;
        }
    }
}
