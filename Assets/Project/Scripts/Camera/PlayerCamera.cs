using UnityEngine;


namespace Project.Scripts.Camera
{
    public class PlayerCamera : MonoBehaviour
    {

        [SerializeField] private Transform _playerTransform;

        private Transform _transform;

        private Vector3 _targetPosition;
        private Vector3 _smoothedPosition;

        private float _smoothSpeed = 6;

        private void Start()
        {
            _transform = gameObject.transform;
        }

        void LateUpdate()
        {
            _targetPosition = new Vector3(_playerTransform.position.x, _playerTransform.position.y, _transform.position.z);
            _smoothedPosition = Vector3.Lerp(transform.position, _targetPosition, _smoothSpeed * Time.deltaTime);
            _transform.position = _smoothedPosition;
        }
    }
    
}
