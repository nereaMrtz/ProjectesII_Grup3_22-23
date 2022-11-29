using System;
using Project.Scripts.Managers;
using Project.Scripts.Sound;
using UnityEngine;

public class HoursHand : MonoBehaviour
{
    [SerializeField] Transform minutes, hours;

    [SerializeField] private GameObject _hammer;
    
    [SerializeField] private float _minMinutes = 175f;
    [SerializeField] private float _maxMinutes = 180f;
    [SerializeField] private float _minHours = 85f;
    [SerializeField] private float _maxHours = 95f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            minutes.Rotate(Vector3.back, 30f * Time.deltaTime);
        }
        
        else if (Input.GetKey(KeyCode.A))
        {
            minutes.Rotate(Vector3.back, -30f * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            hours.Rotate(Vector3.back, 30f * Time.deltaTime);
        }
        
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            hours.Rotate(Vector3.back, -30f * Time.deltaTime);
        }
        
        if ((Mathf.Abs(minutes.rotation.eulerAngles.z) >= _minMinutes && Mathf.Abs(minutes.rotation.eulerAngles.z) <= _maxMinutes) && 
            (Mathf.Abs(hours.rotation.eulerAngles.z) >= _minHours && Mathf.Abs(hours.rotation.eulerAngles.z) <= _maxHours))
        {
            Debug.Log("hola putita");
            // Desactivar pop up
            
            // Aparecer martillo
            _hammer.SetActive(true);
        }
    }
}
 
