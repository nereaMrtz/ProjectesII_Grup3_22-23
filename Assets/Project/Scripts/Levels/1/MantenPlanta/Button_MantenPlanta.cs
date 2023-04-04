using System;
using Project.Scripts.Levels._1._1_1;
using Project.Scripts.Levels._1.Manten;
using UnityEngine;

namespace Project.Scripts.Levels._1.MantenPlanta
{
    public class Button_MantenPlanta : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        [SerializeField] private Door_Manten _door_MantenPlanta;

        [SerializeField] private Flowerpot_MantenPlanta _flowerpot;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.name == "Flowerpot")
            { 
                _flowerpot.SetCorrectPlace(true);
            }

            _animator.SetTrigger("Press");
            
            _door_MantenPlanta.AnimatorStep(true);
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.name == "Flowerpot")
            {
                _flowerpot.SetCorrectPlace(false);
            }
            
            _animator.SetTrigger("Press");
            
            _door_MantenPlanta.AnimatorStep(false);
            _door_MantenPlanta.ChangePolygonCollider(0);
        }

        public void AnchorThePot()
        {
            Destroy(_flowerpot);
            Destroy(this);
        }
    }
}
