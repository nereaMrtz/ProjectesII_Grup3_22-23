using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.Scripts.ZoomInForPuzzles
{
    public class DraggablePuzzleObject : MonoBehaviour, IPointerDownHandler
    {
        enum TypeOfDrag
        {
            ROTATE,
            MOVE
        };

        [SerializeField] private TypeOfDrag typeOfDrag;

        [SerializeField] private Vector3 _position;

        [Range(-360,360)]
        [SerializeField] private float _rotation;
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }
    }
}
