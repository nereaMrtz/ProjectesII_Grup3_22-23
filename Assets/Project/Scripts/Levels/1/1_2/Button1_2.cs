using Project.Scripts.Levels._1._1_1;
using UnityEngine;

namespace Project.Scripts.Levels._1._1_2
{
    public class Button1_2 : Button1_1
    {

        private int _pressCounter;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != 6)
            {
                return;
            }
            _pressCounter++;
            if (_pressCounter == 3)
            {
                _door.Unlock();
            }
            ButtonAction();
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != 6)
            {
                return;
            }
            ButtonAction();
        }
    }
}
