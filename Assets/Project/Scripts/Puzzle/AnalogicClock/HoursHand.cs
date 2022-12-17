using System;
using Project.Scripts.Managers;
using UnityEngine;

public class HoursHand : MonoBehaviour
{
    [SerializeField] Transform minutes, hours;

    [SerializeField] private GameObject _hammer;
    
    [SerializeField] private float _minMinutes = 175f;
    [SerializeField] private float _maxMinutes = 180f;
    [SerializeField] private float _minHours = 85f;
    [SerializeField] private float _maxHours = 95f;

    [SerializeField] private GameObject _panel;

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
            _panel.SetActive(false);
            
            GameManager.Instance.SetZoomInState(false);
            
            _hammer.SetActive(true);
        }
    }
}
 
