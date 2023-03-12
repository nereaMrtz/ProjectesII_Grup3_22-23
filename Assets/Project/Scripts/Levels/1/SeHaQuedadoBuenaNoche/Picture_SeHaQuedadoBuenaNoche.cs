using UnityEngine;

namespace Project.Scripts.Levels._1.SeHaQuedadoBuenaNoche
{
    public class Picture_SeHaQuedadoBuenaNoche : MonoBehaviour
    {
        private const int PLAYER_LAYER = 6;

        [SerializeField] private GameObject _scenario;
        [SerializeField] private GameObject _secretRoom;

        [SerializeField] private SpriteRenderer _doorSpriteRenderer;
        
        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }

            _scenario.SetActive(!_scenario.activeSelf);  
            _secretRoom.SetActive(!_scenario.activeSelf);
            _doorSpriteRenderer.enabled = !_doorSpriteRenderer.enabled;
        }
    }
}
