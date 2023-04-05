using UnityEngine;

namespace Project.Scripts.Levels._1.DibujaTuCamino
{
    public class Cursor_DibujaTuCamino : MonoBehaviour
    {
        [SerializeField] private GameObject _button;
        
        [SerializeField] private SpriteMask _spriteMask;

        [SerializeField] private BoxCollider2D _boxCollider2D;

        private bool _clicking;
        
        private void Update()
        {

            if (Input.GetMouseButtonDown(0))
            {
                _clicking = true;
                _spriteMask.enabled = _clicking;
                _button.SetActive(_clicking);
                _button.transform.position = RandomPointInBounds(_boxCollider2D.bounds);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _clicking = false;
                _spriteMask.enabled = _clicking;
                _button.SetActive(_clicking);   
            }

            if (!_clicking)
            {
                return;
            }
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            transform.position = mousePosition;
        }
        
        private Vector3 RandomPointInBounds(Bounds bounds) {
            return new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y),
                Random.Range(bounds.min.z, bounds.max.z)
            );
        }

    }
}
