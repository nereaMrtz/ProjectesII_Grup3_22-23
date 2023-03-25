using UnityEngine;

namespace Project.Scripts.FeedbackComments 
{
    public class ActivateDialog : MonoBehaviour
    {
        public DialogText text;

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
                FindObjectOfType<DialogController>().ActivateDialogBox(text);
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
                FindObjectOfType<DialogController>().CloseDialogBox();
        }
    }

}