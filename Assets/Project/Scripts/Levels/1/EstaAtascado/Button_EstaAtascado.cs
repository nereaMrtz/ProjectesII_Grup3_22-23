using Project.Scripts.Levels._1.Logico;
using UnityEngine;

namespace Project.Scripts.Levels._1.EstaAtascado
{
    public class Button_EstaAtascado : Button_Logico
    {
        private int _pressCounter;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            _pressCounter++;
            if (_pressCounter == 3)
            {
                _door.Unlock();
            }
            _audioSourcePressButton.Play();
            ButtonAction();
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            _audioSourceReleaseButton.Play();
            ButtonAction();
        }
    }
}
