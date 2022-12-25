using Project.Scripts.Character;
using Project.Scripts.Level;
using UnityEngine;

namespace Project.Scripts.Interactable
{
    public abstract class InteractableScript : MonoBehaviour
    {
        [SerializeField] private Vector3 _pointOffset;

        [SerializeField] private ModifyUIButtonActiveSelf _modifyUIBUttonActiveSelf;
        
        [SerializeField] private GameObject _pointPrefab;
        
        protected GameObject _pointButton;

        [SerializeField] private Player _player;
        
        [SerializeField] protected SpriteRenderer _spriteRenderer;

        [SerializeField] private float _distanceToInteract;

        private RectTransform _rectTransform;
        void Awake()
        {
            _pointButton = Instantiate(_pointPrefab, transform);
            _pointButton.transform.position += _pointOffset;
            _pointButton.SetActive(false);
            _modifyUIBUttonActiveSelf.AddUIButton(_pointButton);
        }

        private void OnMouseDown()
        {
            Interact();            
        }

        private void Interact()
        {
            _player.SetGameObjectAndHisDistanceToInteract(gameObject, _distanceToInteract);
        }
    }
}
