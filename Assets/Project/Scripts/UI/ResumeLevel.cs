using Project.Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.UI
{
    public class ResumeLevel : MonoBehaviour
    {
        [SerializeField] Button resumeButton;

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && GameManager.Instance.IsPause())
            {
                resumeButton.onClick.Invoke();
            }
        }
    }
}