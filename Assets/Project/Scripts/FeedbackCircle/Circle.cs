using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace Project.Scripts.FeedbackCircle
{
    public class Circle : MonoBehaviour
    {
        private const string SHOW_INVENTORY = "ShowInventory";
        [SerializeField] private GameObject biggerCircle;
        [SerializeField] private GameObject quitCircle;
        [SerializeField] private Animator _animator;

        public void ActiveCircle()
        {
            biggerCircle.SetActive(!biggerCircle.activeSelf);
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                ActiveCircle();
                _animator.SetBool(SHOW_INVENTORY, true);
            }
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                ActiveCircle();
                _animator.SetBool(SHOW_INVENTORY, false);
            }
        }

        public void EndCircle()
        {
            quitCircle.SetActive(false);
        }
    }
}

