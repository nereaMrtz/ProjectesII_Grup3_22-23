using Project.Scripts.FeedbackComments;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Intro : MonoBehaviour
{
    private Queue<string> dialogs = new Queue<string>();
    public DialogText text;
    [SerializeField] TextMeshProUGUI screenText;
    [SerializeField] private GameObject clickSprite;

    bool OnDialog = false;
    bool writtingText = false;
    bool onIntro = true;

    private IEnumerator _coroutine;
    private float time = 0.05f;

    private void Start()
    {
        SetDialog(text);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickSprite.SetActive(false);
            NextSentence();
        }
    }

    public void SetDialog(DialogText objectText)
    {
        OnDialog = true;
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
        if (dialogs.Count == 0)   //Si se ha acabado el dialogo, cerramos el cartel
        {
            CloseDialogBox();
            OnDialog = false;
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
        writtingText = true;
        screenText.text = "";
        foreach (char character in textToShow.ToCharArray())
        {
            screenText.text += character;
            yield return new WaitForSeconds(time);
        }
        clickSprite.SetActive(true);
        writtingText = false;
    }
}
