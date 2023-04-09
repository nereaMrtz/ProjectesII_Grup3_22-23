using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.Scripts.Levels._1.Notob
{
    public class Letter_Notob : MonoBehaviour, IPointerUpHandler
    {
        [SerializeField] private Controller_Notob _controllerNotob;
        
        public void OnPointerUp(PointerEventData eventData)
        {
            _controllerNotob.CheckOrder();
        }

        public void Move()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            transform.position = mousePosition;
        }
    }
}
