using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.Scripts.Character
{
    public class TargetPathFinder : MonoBehaviour
    {

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 mousePosition = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
            }
        }
    }
}
