using UnityEngine;

namespace Project.Scripts.Levels._1.BajaHaciaArriba
{
    public class Teleport_BajaHaciaArriba : MonoBehaviour
    {
        private const int PLAYER_LAYER = 6;

        [SerializeField] private Teleport_BajaHaciaArriba _pointToTeleport;

        [SerializeField] private GameObject _player;

        [SerializeField] private Vector3 _offsetTeleport;

        private Vector3 _offsetCapsuleCollider = new Vector3(0, -0.56f, 0);

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            
            _player.transform.position = _pointToTeleport.transform.position + _offsetTeleport - _offsetCapsuleCollider;
        }
    }
}
