using UnityEngine;

namespace Project.Scripts.Camera {

    public abstract class CameraBoundingShapeTrigger : MonoBehaviour
    {
        protected const int PLAYER_LAYER = 6;

        [SerializeField] protected CameraMovement _cameraMovement;

        [SerializeField] protected PolygonCollider2D _enterFromTop;
        [SerializeField] protected PolygonCollider2D _enterFromDown;
        [SerializeField] protected PolygonCollider2D _enterFromRight;
        [SerializeField] protected PolygonCollider2D _enterFromLeft;

        protected PolygonCollider2D _currentPolygonCollider2D;
        protected PolygonCollider2D _lastPolygonCollider2D;
        
        private void OnTriggerEnter2D(Collider2D collision2D)
        {
            if (collision2D.gameObject.layer == PLAYER_LAYER)
            {
                
            }
        }
    }
}