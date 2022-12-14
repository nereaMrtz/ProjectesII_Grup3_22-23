using System;
using UnityEngine;

namespace Project.Scripts.Puzzle.OrderButtonPuzzle
{
    public class ButtonPuzzle : PuzzleScript
    {
        private const String NOT_REQUIRED_INVENTORY_INTERACTABLE = "NotRequiredInventoryInteractable"; 
        
        [SerializeField] private OrderButton[] _orderButtons;

        [SerializeField] private String _correctCombination;

        [SerializeField] private int _currentPressedButtonCounter;

        [SerializeField] private String _currentCombination;

        void Update()
        {
            if (_currentPressedButtonCounter == _orderButtons.Length)
            {
                if (_currentCombination == _correctCombination)
                {
                    foreach (OrderButton orderButton in _orderButtons)
                    {
                        orderButton.ChangeColor(new Color(0.02f, 1f, 0f));
                    }
                    _completed = true;
                }
                else
                {
                    for (int i = 0; i < _orderButtons.Length; i++)
                    {
                        _orderButtons[i].ChangeColor(new Color(1f, 0f, 0.02f));
                        _orderButtons[i].gameObject.layer = LayerMask.NameToLayer(NOT_REQUIRED_INVENTORY_INTERACTABLE);
                    }
                    _currentCombination = "";
                    _currentPressedButtonCounter = 0;
                }
                
            }
            else
            {
                CheckButtonPress();
            }
        }

        private void CheckButtonPress()
        {
            for (int i = 0; i < _orderButtons.Length; i++)
            {
                OrderButton orderButton = _orderButtons[i];
                if (orderButton.IsPressed())
                {
                    orderButton.ChangeColor(new Color(1f, 0.76f, 0f));
                    _currentCombination += 0 + _orderButtons[i].GetPressOrder();
                    orderButton.gameObject.layer = 0;
                    orderButton.SetPressed(false);
                    _currentPressedButtonCounter++;
                }
            }
        }
    }
}
