using UnityEngine;

namespace Project.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;

        private bool _drugged;
        private bool _zoomInState;
        private bool _interactableClicked;
        private bool _clickOnEdge;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }
        
        public static GameManager Instance
        {
            get { return _instance; }
        }

        public void SetDrugged(bool drugged)
        {
            _drugged = drugged;
        }
        
        public bool IsDrugged()
        {
            return _drugged;
        }

        public void SetZoomInState(bool zoomInState)
        {
            _zoomInState = zoomInState;
        }
        
        public bool IsInZoomInState()
        {
            return _zoomInState;
        }

        public void SetInteractableClicked(bool interactableClicked)
        {
            _interactableClicked = interactableClicked;
        }

        public bool IsInteractableClicked()
        {
            return _interactableClicked;
        }
        
        public bool IsClickingOnEdge() 
        { 
            return _clickOnEdge; 
        } 
 
        public void SetClickOnEdge(bool clickOnEdge) 
        { 
            _clickOnEdge = clickOnEdge; 
        } 
    }
}