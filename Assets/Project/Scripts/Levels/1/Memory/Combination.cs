using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combination : MonoBehaviour
{
    //verde azul amarillo lila
    [SerializeField] CapsuleCollider2D Green;
    [SerializeField] CapsuleCollider2D Blue;
    [SerializeField] CapsuleCollider2D Yellow;
    [SerializeField] CapsuleCollider2D Purple;

    int[] combination = new int[5];
    List<int> combinationList = new List<int>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(Green.IsTouchingLayers(6))
        {
            Debug.Log("verde");
        }
    }
}
