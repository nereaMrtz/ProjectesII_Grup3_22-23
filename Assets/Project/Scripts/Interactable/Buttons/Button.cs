using UnityEngine;

namespace Project.Scripts.Interactable.Buttons
{
    public class Button : MonoBehaviour
    {
        [SerializeField] private GameObject _actualPanel;
        [SerializeField] private GameObject _panelToActivate;

        private GameObject _currentActivePanel;

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                ChangePanelButton();
            }
        }

        private void ChangePanelButton()
        {
            _panelToActivate.SetActive(true);
            _actualPanel.SetActive(false);
            (_actualPanel, _panelToActivate) = (_panelToActivate, _actualPanel);
        }
    }
}
