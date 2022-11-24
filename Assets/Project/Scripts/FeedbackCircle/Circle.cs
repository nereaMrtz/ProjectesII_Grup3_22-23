using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace Project.Scripts.FeedbackCircle
{
    public class Circle : MonoBehaviour
    {
        [SerializeField] private GameObject biggerCircle;
        [SerializeField] private GameObject inventory;
        [SerializeField] private GameObject quitCircle;

        public void ActiveCircle()
        {
            biggerCircle.SetActive(!biggerCircle.activeSelf);
        }

        public void ShowInventory()
        {
            inventory.SetActive(!inventory.activeSelf);
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                ActiveCircle();
                ShowInventory();
            }
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                ActiveCircle();
                ShowInventory();
            }
        }
   

       public void EndCircle()
        {
            quitCircle.SetActive(false);
        }
    }  
  
}

