using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Combination : MonoBehaviour
{
    //[SerializeField] private List<GameObject> feedback;
    int feedbackCounter = 0;
    List<int> combinationList = new List<int>();

    protected void AddColor(int button)
    {
        combinationList.Add(button);
        Debug.Log(button);
        //feedback[feedbackCounter].SetActive(true);
        feedbackCounter++;
    }

    private void Update()
    {
        //Orden = verde0, azul1 ,amarillo2, lila3 
        //Respuesta = lila3, amarillo2, verge0, lila3, azul1
        if(combinationList.Count==4)
        {
            //Debug.Log("ha llegao6952.96");

            if (combinationList[0] == 3 && combinationList[1] == 2 && combinationList[2] == 0 && combinationList[3] == 3 && combinationList[4] == 1)
            {
                Debug.Log("Correcto");
            }

        }
    }

}
