using UnityEngine;

namespace Project.Scripts.Levels._1.TiempoApremia
{
    public class Button_TiempoApremia : MonoBehaviour
    {

        private const int PLAYER_LAYER = 6;
        
        [SerializeField] private Door_TiempoApremia _door;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            _door.AnimatorStep();
        }
    }
}
