using System.Collections;
using System.Collections.Generic;
using Project.Scripts.Managers;
using TMPro;
using UnityEngine;

namespace Project.Scripts.FeedbackComments 
{
    public class DialogController : MonoBehaviour
    {
        [SerializeField] private Animator anim;
        [SerializeField] private GameObject pressKey;

        private Queue<string> dialogs = new Queue<string>();
        DialogText text;
        [SerializeField] TextMeshProUGUI screenText;

        bool OnDialog = false;
        bool writtingText = false;

        private IEnumerator _coroutine;
        private float time = 0.05f;
        private void Update()
        {

            if (GameManager.Instance.IsInZoomInState()) 
            {
                pressKey.SetActive(false);
                CloseDialogBox();
            }
            if (OnDialog && Input.GetKeyDown(KeyCode.R) && !writtingText)
            {
                pressKey.SetActive(false);
                NextSentence();
            }
            else if (OnDialog && Input.GetKeyDown(KeyCode.R) && writtingText)
            {
                time = 0.001f;
            }
        }

        public void ActivateDialogBox(DialogText objectText)
        {
            OnDialog = true;
            anim.SetBool("dialogBox", true);
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
            anim.SetBool("dialogBox", false);
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

            pressKey.SetActive(true);
            writtingText = false;
        }
    }

}
