using System;
using Project.Scripts.Character;
using Project.Scripts.Level;
using UnityEngine;

namespace Project.Scripts.Interactable
{
    public abstract class InteractableScript : MonoBehaviour
    {
        private const String SHADER_THICKNESS_VALUE = "_Thickness"; 
        
        [SerializeField] private Vector3 _pointOffset;

        [SerializeField] private ModifyUIButtonActiveSelf _modifyUIBUttonActiveSelf;

        [SerializeField] private Material _customShaderMaterial;
        [SerializeField] private Material _defaultShaderMaterial;
        
        [SerializeField] private GameObject _pointPrefab;
        
        private GameObject _pointButton;

        [SerializeField] private Player _player;
        
        [SerializeField] protected SpriteRenderer _spriteRenderer;

        [SerializeField] private float _distanceToInteract;

        private RectTransform _rectTransform;

        private float _thicknessValue;

        private bool _shaderChanged;
            
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

        private void OnMouseEnter()
        {
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

        private void Interact()
        {
            _player.SetGameObjectAndHisDistanceToInteract(gameObject, _distanceToInteract);
        }

        public GameObject GetPointButton()
        {
            return _pointButton;
        }
    }
}
