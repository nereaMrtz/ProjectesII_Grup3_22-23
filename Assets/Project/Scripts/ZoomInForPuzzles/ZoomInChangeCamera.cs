using Cinemachine;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.ZoomInForPuzzles
{
    public class ZoomInChangeCamera : ZoomInPuzzle
    {
        [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;

        private Transform _initialFollowTransform;
        
        public override void Interact()
        {
            base.Interact();

            if (Activate.activeSelf)
            {
                _initialFollowTransform = _cinemachineVirtualCamera.Follow;
                _cinemachineVirtualCamera.Follow = null;
                _cinemachineVirtualCamera.transform.position = 
                    new Vector3(Activate.transform.position.x, Activate.transform.position.y, _cinemachineVirtualCamera.transform.position.z);
            }
            else
            {
                _cinemachineVirtualCamera.Follow = _initialFollowTransform;
            }
        }

        void Update()
        {
            if (!_puzzle.GetCompleted()) return;
            gameObject.layer = 0;
            _cinemachineVirtualCamera.Follow = _initialFollowTransform;
            GameManager.Instance.SetZoomInState(!GameManager.Instance.IsInZoomInState());
            Destroy(this);
        }
    }
}
