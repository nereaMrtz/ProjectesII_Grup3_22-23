using Project.Scripts.Levels._1.Logico;
using UnityEngine;

namespace Project.Scripts.Levels._1.SeparadosAlNacer
{
    public class Button_SeparadosAlNacer : Button_Logico
    {
        private bool _enabled;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            _audioSourcePressButton.Play();
            ButtonAction();

            if (!_enabled)
            {
                return;
            }
            _door.Unlock();
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

        public bool IsEnabled()
        {
            return _enabled;
        }

        public void EnableButton()
        {
            _enabled = true;
        }
    }
}
