using System;
using UnityEngine;

namespace Project.Scripts.Levels._1.RealidadCuantica
{
    public class Teleport_RealidadCuantica : MonoBehaviour
    {
        private const int PLAYER_LAYER = 6;

        [SerializeField] private ControllerTeleport_RealidadCuantica _controllerTeleport;

        [SerializeField] private Teleport_RealidadCuantica _pointToTeleport;

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

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
        }
    }
}
