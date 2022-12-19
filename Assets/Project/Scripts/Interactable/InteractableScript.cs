using Project.Scripts.Character;
using Project.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Interactable
{
    public abstract class InteractableScript : MonoBehaviour
    {
        [SerializeField] private Vector3 _interactablePointOffset;
        
        [SerializeField] protected Canvas _scenarioInteractableCanvas;
        
        [SerializeField] private GameObject _pointPrefab;

        [SerializeField] private Player _player;

        [SerializeField] private float _distanceToInteract;
        
        private RectTransform _rectTransform;
        
        void Awake()
        {
            GameObject point = Instantiate(_pointPrefab, _scenarioInteractableCanvas.transform);
            point.name = "InteractableSignal" + gameObject.name; 
            _rectTransform = point.GetComponent<RectTransform>();
            _rectTransform.transform.localScale = Vector3.one;
            InteractableUIButton interactableUIButton = point.GetComponent<InteractableUIButton>();
            interactableUIButton.SetGameObjectAndHisDistanceToInteract(gameObject, _distanceToInteract);
            interactableUIButton.SetPlayer(_player);
        }

        void Update()
        {
            _rectTransform.position = gameObject.transform.position + _interactablePointOffset;
        }
    }
}
