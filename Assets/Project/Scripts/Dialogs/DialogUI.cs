using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogUI : MonoBehaviour
{
    private Queue<string> dialogs = new Queue<string>();
    public DialogText text;
    [SerializeField] TextMeshProUGUI screenText;
    [SerializeField] private GameObject clickSprite;
    [SerializeField] Button button;

    private IEnumerator _coroutine;
    private float time = 0.05f;

    void OnMouseDown() {
 
        if (Input.GetMouseButtonDown(0))
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(NextSentence);
            clickSprite.SetActive(false);
            SetDialog(text);
        }
    }
 
    public void SetDialog(DialogText objectText)
    {

        ActivateText();
        text = objectText;
    }

    public void ActivateText()
    {
        screenText.enabled = true;
        dialogs.Clear();    //Borro el texto que habia antes en la cola
        foreach (string saveText in text.textArray) //Me guardo todos los textos de cada array y los meto en la cola
        {
            dialogs.Enqueue(saveText);
        }
        NextSentence();
    }
    public void NextSentence()
    {
        clickSprite.SetActive(false);
        if (dialogs.Count == 0)   //Si se ha acabado el dialogo, cerramos el cartel
        {
            CloseDialogBox();

            return;
        }

        time = 0.05f;

        string actualSentence = dialogs.Dequeue();
        screenText.text = actualSentence;
        _coroutine = ShowCharacters(actualSentence);
        StartCoroutine(_coroutine);

    }

    public void CloseDialogBox()
    {
        screenText.text = "";
        screenText.enabled = false;
        StopCoroutine(_coroutine);
    }

    IEnumerator ShowCharacters(string textToShow)
    {
        screenText.text = "";
        foreach (char character in textToShow.ToCharArray())
        {
            screenText.text += character;
            yield return new WaitForSeconds(time);
        }
        clickSprite.SetActive(true);
    }
}
