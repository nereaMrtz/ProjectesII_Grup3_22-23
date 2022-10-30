using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


namespace Project.Scripts.Interactable.Static
{
    public class Door : InteractableScript
    {
        private Transform _transform;
        
        [SerializeField] private Rigidbody2D _rigidbody2D;

        private bool _unlocked;

        private void Start()
        {
            _transform = gameObject.transform;
        }

        public override void Interact()
        {
            if (_unlocked)
            {
                StartCoroutine(Open());
            }
        }

        private IEnumerator Open()
        {

            yield return new WaitForSeconds(0);
            //yield return new WaitUntil();
        }
    }
    
}
