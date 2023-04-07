using UnityEngine;

namespace Project.Scripts.Levels._1.SeparadosAlNacer
{
    public class ElectricityReceiver_SeparadosAlNacer : MonoBehaviour
    {
        [SerializeField] private ElectricityPanel_SeparadosAlNacer _electricityPanel;

        [SerializeField] private Button_SeparadosAlNacer _button;

        [SerializeField] private SpriteRenderer _spriteRenderer;

        private float _timeToConnect = 1;

        private void OnMouseEnter()
        {
            if (_button.IsEnabled())
            {
                return;
            }
            
            if (Time.time - _electricityPanel.GetTime() > _timeToConnect)
            {
                return;
            }
            _spriteRenderer.color = new Color(1, 1, 1);
            _button.EnableButton();
        }
    }
}
