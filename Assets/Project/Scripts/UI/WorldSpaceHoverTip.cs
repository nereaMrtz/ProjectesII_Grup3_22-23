using UnityEngine;

namespace Project.Scripts.UI
{
    public class WorldSpaceHoverTip : HoverTip
    {
        private SpriteRenderer _spriteRendererOfGameObjectAttached;

        private void Start()
        {
            _spriteRendererOfGameObjectAttached = _gameObjectAttached.GetComponent<SpriteRenderer>();
            _rectTransform = gameObject.GetComponent<RectTransform>();
            _tipText = _gameObjectAttached.name;
        }

        private void Update()
        {
            if (_spriteRendererOfGameObjectAttached.enabled)
            {
                transform.position = _gameObjectAttached.transform.position;
                _rectTransform.sizeDelta = _spriteRendererOfGameObjectAttached.size;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
