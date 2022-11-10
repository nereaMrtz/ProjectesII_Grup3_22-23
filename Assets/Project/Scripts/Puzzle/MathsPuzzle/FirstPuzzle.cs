using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPuzzle : MonoBehaviour
{
    [SerializeField] private GameObject prueba;
    public void CheckAnswer(string answer)
    {
        int aux = int.Parse(answer);

        if(aux == 11)
            prueba.SetActive(!prueba.activeSelf);
    }
}
