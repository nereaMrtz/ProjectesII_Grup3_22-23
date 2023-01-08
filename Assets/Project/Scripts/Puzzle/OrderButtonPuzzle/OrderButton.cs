using System;
using Project.Scripts.Interactable.Static.NotRequiredInventory;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Puzzle.OrderButtonPuzzle
{
    public class OrderButton : NotRequiredInventoryInteractable
    {
        private const String PRESS_SOUND = "Press Button Or Tile Sound"; 
        
        [SerializeField] private int _pressOrder;

        [SerializeField] private bool _pressed;
        
        public override void Interact()
        {
            _pressed = true;
            AudioManager.Instance.Play(PRESS_SOUND);
        }

        public void ChangeColor(Color color)
        {
            _spriteRenderer.color = color;
        }

        public int GetPressOrder()
        {
            return _pressOrder;
        }

        public void SetPressOrder(int pressOrder)
        {
            _pressOrder = pressOrder;
        }

        public bool IsPressed()
        {
            return _pressed;
        }

        public void SetPressed(bool pressed)
        {
            _pressed = pressed;
        }
    }
}
