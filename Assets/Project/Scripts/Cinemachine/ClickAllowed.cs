using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Cinemachine
{
    public class ClickAllowed : MonoBehaviour
    {
        private void OnMouseDown()
        {
            GameManager.Instance.SetClickOnEdge(true);
            
        }
        private void OnMouseUp()
        {
            GameManager.Instance.SetClickOnEdge(false);
        }
    }
}
