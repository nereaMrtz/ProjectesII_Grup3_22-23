using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace Project.Scripts.FeedbackCircle
{
    public class Circle : MonoBehaviour
    {
        [SerializeField] private GameObject smallCircle;
        [SerializeField] private GameObject quitCircle;

        public void ActiveSmallCircle()
        {
            smallCircle.SetActive(!smallCircle.activeSelf);
       
        }
  
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                ActiveSmallCircle();
           
            }
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                ActiveSmallCircle();
            }
        }

        public void EndCircle()
        {
            quitCircle.SetActive(false);
        }
    }
}

