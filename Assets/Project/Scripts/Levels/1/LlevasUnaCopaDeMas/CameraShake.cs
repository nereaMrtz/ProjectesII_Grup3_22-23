using UnityEngine;

namespace Project.Scripts.Levels._1.LlevasUnaCopaDeMas
{
    public class CameraShake : MonoBehaviour
    {

        [SerializeField] float _magnitude;
        
        private float _nextXPosition;
        
        private Vector3 _currentLocation;
        
        void Start()
        {
            _currentLocation = transform.localPosition;
        }

        private void Update()
        {
            transform.localPosition = new Vector3( Mathf.Sin(Time.timeSinceLevelLoad * _magnitude), _currentLocation.y, _currentLocation.z);
        }
    }
}
