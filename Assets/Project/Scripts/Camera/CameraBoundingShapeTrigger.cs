using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Camera {

    public class CameraBoundingShapeTrigger : MonoBehaviour
    {
        private const int PLAYER_LAYER = 6;

        [SerializeField] private CameraMovement _cameraMovement;

        [SerializeField] private PolygonCollider2D _mainPolygonCollider2D;

        private PolygonCollider2D _polygonCollider2D;

        private void Start()
        {
            _polygonCollider2D = GetComponent<PolygonCollider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision2D)
        {
            if (collision2D.gameObject.layer == PLAYER_LAYER)
            {
                _cameraMovement.ChangeBoundingShape(_polygonCollider2D);
            }
        }

        private void OnTriggerExit2D(Collider2D collision2D)
        {
            if (collision2D.gameObject.layer == PLAYER_LAYER)
            {
                _cameraMovement.ChangeBoundingShape(_mainPolygonCollider2D);
            }
        }
    }
}