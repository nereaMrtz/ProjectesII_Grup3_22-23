using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.Scripts.Levels._1.Notob
{
    public class Letter_Notob : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
    {
        [SerializeField] private Controller_Notob _controllerNotob;
        
        [SerializeField] private int _letterIndex;

        private bool _clicked;


        public void OnPointerDown(PointerEventData eventData)
        {
            if (_controllerNotob.IsLetterClicked())
            {
                return;
            }

            _controllerNotob.SetLetterClicked(true);
            _clicked = true;
        }
        
        public void OnPointerUp(PointerEventData eventData)
        {
            _controllerNotob.SetLetterClicked(false);
            _clicked = false;
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            if (!_clicked)
            {
                return;
            }

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            transform.position = mousePosition;
        }
    }
}
