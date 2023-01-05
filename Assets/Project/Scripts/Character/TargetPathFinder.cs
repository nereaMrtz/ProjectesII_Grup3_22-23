using Project.Scripts.Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.Scripts.Character
{
    public class TargetPathFinder : MonoBehaviour
    {
        void Update()
        {
            if (GameManager.Instance.IsInZoomInState())
            {
                return;
            }
            
            if (!Input.GetMouseButton(0))
            {
                return;
            }

            if (GameManager.Instance.IsClickingOnEdge())
            {
                return;
            }
            
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
        }
    }
}
