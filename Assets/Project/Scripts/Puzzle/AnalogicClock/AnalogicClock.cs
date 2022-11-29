using System;
using Project.Scripts.Managers;
using Project.Scripts.Sound;
using UnityEngine;

public class AnalogicClock : MonoBehaviour
{
    [SerializeField] Transform minutes, hours;

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            minutes.Rotate(Vector3.back, 30);
        }
    }
}
 
