using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace Project.Scripts.Camera {

    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private CinemachineConfiner2D _cinemachineCameraConfiner;

        public void ChangeBoundingShape(PolygonCollider2D polygonCollider2D) {

            _cinemachineCameraConfiner.m_BoundingShape2D = polygonCollider2D;        
        }
    }

}