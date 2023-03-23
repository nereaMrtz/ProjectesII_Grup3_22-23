using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Combination : MonoBehaviour
{
    //[SerializeField] private List<GameObject> feedback;
    int feedbackCounter;

    int[] combination = new int[5];

    private void Start()
    {
        feedbackCounter = 0;
    }
    protected void AddColor(int button)
    {
        combination[feedbackCounter] = button;
        Debug.Log(button);
        //feedback[feedbackCounter].SetActive(true);
        feedbackCounter++;
    }



    private void Update()
    {
        //Orden = verde0, azul1 ,amarillo2, lila3 
        //Respuesta = lila3, amarillo2, verge0, lila3, azul1
        
        if (combination[0] == 3 && combination[1] == 2 /*&& combination[2] == 0 && combination[3] == 3 && combination[4] == 1*/)
        {
            Debug.Log("pruebesita");
        }

     
    }

}
