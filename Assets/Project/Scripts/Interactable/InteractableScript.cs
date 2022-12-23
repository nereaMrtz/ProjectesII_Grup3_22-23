using Project.Scripts.Character;
using Project.Scripts.Level;
using Project.Scripts.UI;
using UnityEngine;

namespace Project.Scripts.Interactable
{
    public abstract class InteractableScript : MonoBehaviour
    {
        [SerializeField] private Vector3 _pointOffset;
        
        [SerializeField] protected Canvas _scenarioInteractableCanvas;

        [SerializeField] private ModifyUIButtonActiveSelf _modifyUIBUttonActiveSelf;
        
        [SerializeField] private GameObject _interactableAreaPrefab;
        [SerializeField] private GameObject _pointPrefab;

        protected GameObject _interactableAreaPanel;
        protected GameObject _pointButton;

        [SerializeField] private Player _player;
        
        [SerializeField] protected SpriteRenderer _spriteRenderer;

        [SerializeField] private float _distanceToInteract;

        private RectTransform _rectTransform;
        void Awake()
        {
            /*_interactableAreaPanel = Instantiate(_interactableAreaPrefab, _scenarioInteractableCanvas.transform);
            _interactableAreaPanel.name = "InteractableSignal" + gameObject.name;
            _rectTransform = _interactableAreaPanel.GetComponent<RectTransform>();*/
            //InteractableUIButton interactableUIButton = _interactableAreaPanel.GetComponent<InteractableUIButton>();
            //interactableUIButton.SetGameObjectAndHisDistanceToInteract(gameObject, _distanceToInteract);
            //interactableUIButton.SetPlayer(_player);
            _pointButton = Instantiate(_pointPrefab, transform);
            _pointButton.transform.position += _pointOffset;
            _pointButton.SetActive(false);
            _modifyUIBUttonActiveSelf.AddUIButton(_pointButton);
        }

        void Update()
        {
            /*_rectTransform.position = gameObject.transform.position;
            _rectTransform.sizeDelta = _spriteRenderer.size * 45;
            _rectTransform.rotation = transform.rotation;*/
        }

        private void OnMouseDown()
        {
            Debug.Log("Holi");
            Interact();            
        }

        public void Interact()
        {
            _player.SetGameObjectAndHisDistanceToInteract(gameObject, _distanceToInteract);
        }
    }
}
