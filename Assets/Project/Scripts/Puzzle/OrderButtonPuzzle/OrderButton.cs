using Project.Scripts.Interactable.Static.NotRequiredInventory;
using UnityEngine;

namespace Project.Scripts.Puzzle.OrderButtonPuzzle
{
    public class OrderButton : NotRequiredInventoryInteractable
    {
        [SerializeField] private int _pressOrder;

        [SerializeField] private bool _pressed;
        
        public override void Interact()
        {
            _pressed = true;
            //TODO: PRESS BUTTON SOUND
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
