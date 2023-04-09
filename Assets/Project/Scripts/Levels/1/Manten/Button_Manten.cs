using Project.Scripts.Levels._1.Logico;
using UnityEngine;

namespace Project.Scripts.Levels._1.Manten
{
    public class Button_Manten : Button_Logico
    {
        [SerializeField] private float _timeToOpenDoor;

        [SerializeField] private Door_Manten _door_Manten;

        private float _currentTime;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            
            _door_Manten.Open();
            
            _audioSourcePressButton.Play();
            ButtonAction();
            _door_Manten.AnimatorStep(_pressed);
            _currentTime = Time.time;
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            _audioSourceReleaseButton.Play();
            ButtonAction();
            if (Time.time - _currentTime > _timeToOpenDoor && !_door_Manten.IsUnlocked())
            {
                _door_Manten.SetUnlock(true);
            }
            else
            {
                _door_Manten.ChangePolygonCollider(0);
            }
            _door_Manten.AnimatorStep(_pressed);
            
            _currentTime = 0;
        }
    }
}
