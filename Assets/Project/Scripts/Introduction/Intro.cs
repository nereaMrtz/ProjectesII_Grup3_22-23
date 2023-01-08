using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.Introduction
{
    public class Intro : MonoBehaviour
    {
        private Queue<string> dialogs = new Queue<string>();
        public DialogText text;
        [SerializeField] TextMeshProUGUI screenText;
        [SerializeField] private GameObject clickSprite;
        [SerializeField] bool onIntro;

        bool OnDialog = false;
        bool writtingText = false;
       

        private IEnumerator _coroutine;
        private float time = 0.05f;

        private void Start()
        {
            SetDialog(text);
        }

        private void Update()
        {
                time = 0.05f;

            if (OnDialog && Input.GetMouseButtonDown(0) && !writtingText)
            {
                clickSprite.SetActive(false);
                NextSentence();
            }
            if (OnDialog && Input.GetMouseButtonDown(0) && writtingText)
            {
                time = 0.001f;
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
                if(onIntro)
                    SceneManager.LoadScene(2);
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
}
