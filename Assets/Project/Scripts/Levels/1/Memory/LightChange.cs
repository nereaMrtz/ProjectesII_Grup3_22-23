using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightChange : MonoBehaviour
{
    [SerializeField] Image light;
    Color[] combination = new Color[5];

    private void Start()
    {
        combination[0] = Color.red;
        combination[1] = Color.yellow;
        combination[2] = Color.green;
        combination[3] = Color.red;
        combination[4] = Color.blue;
    }
    public void ChangeColors()
    {
       StartCoroutine(Change());
    }

     IEnumerator Change()
    {
        for (int i = 0; i < combination.Length; i++)
        {
            light.color = combination[i];
            yield return new WaitForSeconds(1);
        }
    }
}
