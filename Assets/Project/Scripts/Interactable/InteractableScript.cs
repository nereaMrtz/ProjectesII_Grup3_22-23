using Project.Scripts.Character;
using Project.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Interactable
{
    public abstract class InteractableScript : MonoBehaviour
    {
        [SerializeField] private Vector3 _pointOffset;
        
        [SerializeField] protected Canvas _scenarioInteractableCanvas;
        
        [SerializeField] private GameObject _interactableAreaPrefab;
        [SerializeField] private GameObject _pointPrefab;

        [SerializeField] private Player _player;
        
        [SerializeField] protected SpriteRenderer _spriteRenderer;

        [SerializeField] private float _distanceToInteract;

        private RectTransform _rectTransform;
        void Awake()
        {
            GameObject interactableArea = Instantiate(_interactableAreaPrefab, _scenarioInteractableCanvas.transform);
            interactableArea.name = "InteractableSignal" + gameObject.name;
            _rectTransform = interactableArea.GetComponent<RectTransform>();
            InteractableUIButton interactableUIButton = interactableArea.GetComponent<InteractableUIButton>();
            interactableUIButton.SetGameObjectAndHisDistanceToInteract(gameObject, _distanceToInteract);
            interactableUIButton.SetPlayer(_player);
            GameObject point = Instantiate(_pointPrefab, transform);
            point.transform.position += _pointOffset;
        }

        void Update()
        {
            _rectTransform.position = gameObject.transform.position;
            _rectTransform.sizeDelta = _spriteRenderer.size * 45;
            _rectTransform.rotation = transform.rotation;
        }
    }
}
