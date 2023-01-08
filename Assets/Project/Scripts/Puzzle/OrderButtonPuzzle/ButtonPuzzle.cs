using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Project.Scripts.Puzzle.OrderButtonPuzzle
{
    public class ButtonPuzzle : PuzzleScript
    {
        private const String NOT_REQUIRED_INVENTORY_INTERACTABLE = "NotRequiredInventoryInteractable"; 
        
        [SerializeField] private OrderButton[] _orderButtons;

        [SerializeField] private String _correctCombination;
        [SerializeField] private String _currentCombination;

        [SerializeField] private int _currentPressedButtonCounter;

        [SerializeField] private GameObject[] _numbers;

        private Vector3[] _offsetOfNumbers;

        private void Start()
        {
            _offsetOfNumbers = new Vector3[_numbers.Length];
            for (int i = 0; i < _offsetOfNumbers.Length; i++)
            {
                _offsetOfNumbers[i] = _numbers[i].transform.position;
            }
        }

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
                ChangePressOrder();
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
                //_onComplete.Invoke();
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

        private void ChangePressOrder()
        {
            List<int> availableNumbers = new List<int>();

            for (int i = 0; i < _orderButtons.Length; i++)
            {
                availableNumbers.Add(i + 1);
            }
            
            for (int i = 0; i < _orderButtons.Length; i++)
            {
                int numberPicked = PickNumberFromList(availableNumbers);
                _orderButtons[i].SetPressOrder(numberPicked);
                _numbers[numberPicked - 1].transform.position = _offsetOfNumbers[i];
            }
        }

        private int PickNumberFromList(List<int> availableNumbers)
        {
            int randomNumber = Random.Range(0, availableNumbers.Count);

            int numberPicked = availableNumbers[randomNumber];
            availableNumbers.RemoveAt(randomNumber);

            return numberPicked;
        }
    }
}
