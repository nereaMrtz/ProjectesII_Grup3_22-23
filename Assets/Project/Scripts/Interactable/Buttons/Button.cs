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
            /*if (Input.GetKeyDown(KeyCode.F))
            {
                ChangePanelButton();
            }*/
        }

        public void ChangePanelButton()
        {
            _actualPanel.SetActive(false);
            _panelToActivate.SetActive(true);
            (_actualPanel, _panelToActivate) = (_panelToActivate, _actualPanel);
            
            // Desactivat caminar player
        }

        public void ExitButton()
        {
            _actualPanel.SetActive(false);
        }
    }
}
