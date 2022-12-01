using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject _actualPanel;
    [SerializeField] private GameObject _panelToActivate;
    [SerializeField] private GameObject _auxiliarPanel;

    public void ChangePanelButton()
    {
        _panelToActivate.SetActive(true);
        _actualPanel.SetActive(false);
        _actualPanel = _panelToActivate;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_panelToActivate.activeSelf)
            {
                _panelToActivate.SetActive(false);
            }
            else if (!_panelToActivate.activeSelf)
            {
                _panelToActivate.SetActive(true);
                _actualPanel.SetActive(false);
            }
        }
    }
}
