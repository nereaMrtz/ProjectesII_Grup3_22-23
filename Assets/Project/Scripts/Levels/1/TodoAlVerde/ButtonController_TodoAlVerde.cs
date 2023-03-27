using Project.Scripts.Levels._1._1_1;
using UnityEngine;

namespace Project.Scripts.Levels.TodoAlVerde 
{
    public class ButtonController_TodoAlVerde : MonoBehaviour
    {
        [SerializeField] private Button_TodoAlVerde[] _buttons;

        [SerializeField] private Door _door;

        [SerializeField] private bool[] _correctButtons;

        private bool _allCorrect;

        private void Start()
        {
            _correctButtons = new bool[_buttons.Length];
        }

        public void SetCorrectButton(int index) {
            _correctButtons[index] = true;

            _allCorrect = true;

            for (int i = 0; i < _correctButtons.Length; i++)
            {
                _allCorrect = _correctButtons[i];
                if (!_allCorrect) {
                    i = _correctButtons.Length - 1;
                    continue;
                }
            }
            if (_allCorrect)
            {
                _door.Unlock(0.1f);
            }                
        }

        public void SetFalseToAllButtons() {
            for (int i = 0; i < _correctButtons.Length; i++)
            {
                _correctButtons[i] = false;
                _buttons[i].SetCorrectFalse();
            }
        }
    }
}