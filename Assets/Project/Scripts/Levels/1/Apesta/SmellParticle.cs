using UnityEngine;

namespace Project.Scripts.Levels._1.Apesta
{
    public class SmellParticle : MonoBehaviour
    {
        private void Update()
        {
            transform.position = GetMouseWorldCoordinates();
        }


        private Vector3 GetMouseWorldCoordinates()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            return mousePosition;
        }
    }
}
