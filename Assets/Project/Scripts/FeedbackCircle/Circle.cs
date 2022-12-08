using Project.Scripts.ProjectMaths;
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
        [SerializeField] private SpriteRenderer smallCircleRenderer;
        [SerializeField] private CircleCollider2D circleCollider;
        private float maxDistance;
        private float currentDistance;

        private void Start()
        {
            maxDistance = circleCollider.radius;
        }

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

        private void OnTriggerStay2D(Collider2D collision)
        {

            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                float alpha = CustomMath.Map(currentDistance, 2, maxDistance, 1, 0.2f);

                currentDistance = Vector3.Distance(transform.position, collision.transform.position);
                Color circleColor = smallCircleRenderer.color;
                circleColor = new Color(circleColor.r, circleColor.g, circleColor.b, alpha);
                smallCircleRenderer.color = circleColor;
            }
        }


    }
}

