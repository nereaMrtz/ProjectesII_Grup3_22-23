using Project.Scripts.ProjectMaths;
using UnityEngine;

namespace Project.Scripts.Character
{
    public class ThrowUp : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private Color _color;
        
        [SerializeField] private float _timeToDisappear;
        
        private Vector2 _size;
        private Vector2 _currentSize;

        private float _currentTimeToDisappear;

        private void Start()
        {
            _color = _spriteRenderer.color;
            _size = _spriteRenderer.size;
        }

        private void OnEnable()
        {
            _currentTimeToDisappear = _timeToDisappear;
            _currentSize = _size;
        }

        void Update()
        {
            _currentTimeToDisappear -= Time.deltaTime;

            if (_currentTimeToDisappear > _timeToDisappear / 3)
            {
                _color.a = CustomMath.Map(_currentTimeToDisappear, _timeToDisappear / 3,
                    _timeToDisappear, 0.7f, 1);
            }
            else
            {
                _color.a = CustomMath.Map(_currentTimeToDisappear, 0, _timeToDisappear / 3, 0, 0.7f);
            }

            if (_currentTimeToDisappear > _timeToDisappear - _timeToDisappear / 3)
            {
                _currentSize.x = CustomMath.Map(_currentTimeToDisappear, _timeToDisappear - _timeToDisappear / 3,
                    _timeToDisappear, _size.x - _size.x / 3, 0.1f);
                _currentSize.y = CustomMath.Map(_currentTimeToDisappear, _timeToDisappear - _timeToDisappear / 3,
                    _timeToDisappear, _size.y - _size.y / 3, 0.1f);
            }
            else
            {
                _currentSize.x = CustomMath.Map(_currentTimeToDisappear, 0,
                    _timeToDisappear - _timeToDisappear / 3, _size.x, _size.x - _size.x / 3);
                _currentSize.y = CustomMath.Map(_currentTimeToDisappear, 0,
                    _timeToDisappear - _timeToDisappear / 3, _size.y, _size.y - _size.y / 3);
            }

            _spriteRenderer.color = _color;
            _spriteRenderer.size = _currentSize;
                
            if (_currentTimeToDisappear <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
