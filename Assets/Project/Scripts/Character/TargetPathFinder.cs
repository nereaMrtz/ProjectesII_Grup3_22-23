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
            if (!Input.GetMouseButtonDown(0))
            {
                return;
            }
            if (GameManager.Instance.IsInteractableClicked())
            {
                GameManager.Instance.SetInteractableClicked(false);
                return;   
            }
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
        }
    }
}
