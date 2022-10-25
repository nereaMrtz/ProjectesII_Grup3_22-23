using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Project.Scripts.ProjectPhysics2D
{
    public class ProjectPhysics2D : MonoBehaviour
    {
        public void Move(Transform transform, Vector3 vector)
        {
            transform.position += vector * Time.deltaTime;
        }
    }
}

