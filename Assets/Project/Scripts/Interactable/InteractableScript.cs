using System;
using Project.Scripts.Character;
using Project.Scripts.Level;
using UnityEngine;

namespace Project.Scripts.Interactable
{
    public abstract class InteractableScript : MonoBehaviour
    {
        private const String SHADER_THICKNESS_VALUE = "_Thickness"; 

        private const string REQUIRED_INVENTORY_INTERACTABLE_LAYER = "RequiredInventoryInteractable";
        private const string NOT_REQUIRED_INVENTORY_INTERACTABLE_LAYER = "NotRequiredInventoryInteractable";
        
        [SerializeField] private Vector3 _pointOffset;

        [SerializeField] private ModifyUIButtonActiveSelf _modifyUIButtonActiveSelf;

        [SerializeField] private GameObject _pointPrefab;

        [SerializeField] private Player _player;
        
        [SerializeField] protected SpriteRenderer _spriteRenderer;

        [SerializeField] private float _distanceToInteract;
        
        private Material _customShaderMaterial;
        private Material _defaultShaderMaterial;

        protected GameObject _pointButton;
        
        private RectTransform _rectTransform;

        private float _thicknessValue;

        private bool _shaderChanged;
            
        void Awake()
        {
            _pointButton = Instantiate(_pointPrefab, transform);
            _pointButton.transform.position += _pointOffset;
            _pointButton.SetActive(false);
            _modifyUIButtonActiveSelf.AddUIButton(_pointButton);
            _customShaderMaterial =
                Resources.Load<Material>("Materials/Shaders/Shader Graphs_SpriteOutline");
            _defaultShaderMaterial = _spriteRenderer.material;
        }

        private void Update()
        {
            if (gameObject.layer != LayerMask.NameToLayer(REQUIRED_INVENTORY_INTERACTABLE_LAYER)
                && gameObject.layer != LayerMask.NameToLayer(NOT_REQUIRED_INVENTORY_INTERACTABLE_LAYER))
            {
                _pointButton.SetActive(false);
            }
            else
            {
                _pointButton.SetActive(true);
            }
        }

        private void OnMouseEnter()
        {
            if (gameObject.layer == 0)
            {
                return;
            }
            _shaderChanged = _pointButton.activeSelf;
            if (!_shaderChanged)
            {
                return;
            }
            _spriteRenderer.material = _customShaderMaterial;
        }

        private void OnMouseOver()
        {
            if (_thicknessValue >= 0.05f || !_shaderChanged)
            {
                return;
            }
            _thicknessValue += Time.deltaTime;
            _spriteRenderer.material.SetFloat(SHADER_THICKNESS_VALUE, _thicknessValue);
        }

        private void OnMouseExit()
        {
            if (!_shaderChanged)
            {
                return;
            }
            _thicknessValue = 0;
            _spriteRenderer.material.SetFloat(SHADER_THICKNESS_VALUE, _thicknessValue);
            _spriteRenderer.material = _defaultShaderMaterial;
        }

        public GameObject GetPointButton()
        {
            return _pointButton;
        }
    }
}
