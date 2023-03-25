using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.FeedbackComments
{
    public class Comments : MonoBehaviour
    {
        [SerializeField] GameObject dialogBox;

        public void ActivateDialogBox()
        {
            dialogBox.SetActive(!dialogBox.activeSelf);
        }

        public void SetComments(AudioManager audioManager)
        {

        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                ActivateDialogBox();
            }
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                ActivateDialogBox();
            }
        }
    }
}