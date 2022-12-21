using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.Scripts.Character
{
    public class TargetPathFinder : MonoBehaviour
    {
        [SerializeField] private Player _player;
        void Update()
        {
            if (!Input.GetMouseButton(0))
            {
                return;
            }
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
        }
    }
}
