using UnityEngine;

namespace Project.Scripts.Levels._1.Obrero
{
    public class Hammer_Obrero : MonoBehaviour
    {
        private const int PLAYER_LAYER = 6;
        
        [SerializeField] private Player_Obrero _playerObrero;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            _playerObrero.GiveHammer();
            Destroy(gameObject);
        }
    }
}
