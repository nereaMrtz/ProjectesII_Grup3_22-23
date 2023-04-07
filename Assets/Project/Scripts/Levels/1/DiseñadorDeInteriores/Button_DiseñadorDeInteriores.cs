using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Project.Scripts.Levels._1.DiseñadorDeInteriores
{
    public class Button_DiseñadorDeInteriores : MonoBehaviour
    {
        [SerializeField] private Controller_DiseñadorDeInteriores _controller;
        
        [SerializeField] private bool _justClicked;


        private void OnMouseDown()
        {
            _controller.SetClickedOnButtonTrue();
            _justClicked = true;
        }

        public bool IsJustClicked()
        {
            return _justClicked;
        }

        public void DenyClick()
        {
            _justClicked = false;
        }
    }
}