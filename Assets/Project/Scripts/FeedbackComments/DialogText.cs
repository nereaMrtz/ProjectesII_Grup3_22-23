using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]   //Este script no se puede arraastrar en inspector, solo se puede llamar desde otros scripts

public class DialogText
{
    [TextArea(2,4)]  //Minimo y maximo de lineas que ocupa
    public string[] textArray;  //Contiene las diferentes cajas de textos
}
