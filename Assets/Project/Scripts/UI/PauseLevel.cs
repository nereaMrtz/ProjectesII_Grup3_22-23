using Project.Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.UI
{
    public class PauseLevel : MonoBehaviour
    {
        [SerializeField] Button pauseButton;

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.Instance.IsPause())
            {
                pauseButton.onClick.Invoke();
            }
        }
    }

}
