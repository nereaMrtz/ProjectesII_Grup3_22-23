using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace Project.Scripts.FeedbackCircle
{
    public class Circle : MonoBehaviour
    {
        private const string SHOW_INVENTORY = "ShowInventory";
        [SerializeField] private GameObject smallCircle;
        [SerializeField] private BoxCollider2D circleColider;
        [SerializeField] private GameObject BigCircle;
        [SerializeField] private GameObject quitCircle;
        [SerializeField] private Animator _animator;

        public void ActiveSmallCircle()
        {
            smallCircle.SetActive(!smallCircle.activeSelf);
       
        }
        
        public void ActiveBigCircle()
        {
            BigCircle.SetActive(!BigCircle.activeSelf);
        }
        

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                ActiveSmallCircle();

               // if ()
               // {
                    ActiveBigCircle();
                    _animator.SetBool(SHOW_INVENTORY, true);
               // }
            }
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                ActiveSmallCircle();

                if (smallCircle.layer == LayerMask.NameToLayer("BiggerCircleTrigger"))
                {
                    ActiveBigCircle();
                    _animator.SetBool(SHOW_INVENTORY, true);


                }
            }
        }

        public void EndCircle()
        {
            quitCircle.SetActive(false);
        }
    }
}

