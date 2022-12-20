using System;
using UnityEngine;

namespace Project.Scripts.Puzzle.OrderButtonPuzzle
{
    public class ButtonPuzzle : PuzzleScript
    {
        private const String NOT_REQUIRED_INVENTORY_INTERACTABLE = "NotRequiredInventoryInteractable"; 
        
        [SerializeField] private OrderButton[] _orderButtons;

        [SerializeField] private String _correctCombination;

        [SerializeField] private String _currentCombination;

        [SerializeField] private int _currentPressedButtonCounter;
        void Update()
        {
            CheckButtonPress();
        }

        private void CheckCombination(OrderButton button)
        {
            button.SetPressed(false);
            if (_currentCombination[_currentPressedButtonCounter] != _correctCombination[_currentPressedButtonCounter])
            {
                for (int i = 0; i < _orderButtons.Length; i++)
                {
                    _orderButtons[i].ChangeColor(new Color(1f, 0f, 0.02f));
                    _orderButtons[i].gameObject.layer = LayerMask.NameToLayer(NOT_REQUIRED_INVENTORY_INTERACTABLE);
                }
                _currentCombination = "";
                _currentPressedButtonCounter = 0;
            }
            else
            {
                button.gameObject.layer = 0;
                _currentPressedButtonCounter++;
                
                if (_currentPressedButtonCounter != _correctCombination.Length)
                {
                    return;
                }

                foreach (OrderButton orderButton in _orderButtons)
                {
                    orderButton.ChangeColor(new Color(0.02f, 1f, 0f));
                }
                _completed = true;
            }
        }

        private void CheckButtonPress()
        {
            for (int i = 0; i < _orderButtons.Length; i++)
            {
                OrderButton orderButton = _orderButtons[i];
                if (!orderButton.IsPressed())
                {
                    continue;
                }
                orderButton.ChangeColor(new Color(1f, 0.76f, 0f));
                _currentCombination += _orderButtons[i].GetPressOrder();
                CheckCombination(orderButton);
            }
        }
    }
}
