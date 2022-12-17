using System;
using Project.Scripts.Interactable.Static.NotRequiredInventory;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Puzzle.OrderButtonPuzzle
{
    public class OrderButton : NotRequiredInventoryInteractable
    {
        [SerializeField] private int _pressOrder;

        [SerializeField] private SpriteRenderer _spriteRenderer;

        private bool _pressed;
        
        public override void Interact(AudioManager audioManager)
        {
            _pressed = true;
        }

        public void ChangeColor(Color color)
        {
            _spriteRenderer.color = color;
        }

        public int GetPressOrder()
        {
            return _pressOrder;
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
