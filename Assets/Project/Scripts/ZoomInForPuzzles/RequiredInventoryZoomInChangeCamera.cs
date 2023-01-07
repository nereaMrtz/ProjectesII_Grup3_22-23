using System;
using Project.Scripts.Character;
using Project.Scripts.Managers;
using Project.Scripts.Puzzle;
using UnityEngine;

namespace Project.Scripts.ZoomInForPuzzles
{
    public class RequiredInventoryZoomInChangeCamera : RequiredInventoryZoomIn
    {
        protected const String OVER_WORLD_CAMERA_STATE = "OverWorldCamera";
        protected const String PUZZLE_CAMERA_STATE = "PuzzleCamera";
        
        [SerializeField] protected PuzzleScript _puzzle;

        [SerializeField] protected Animator _cameraSwitcherAnimator;

        [SerializeField] protected GameObject _keyObject;
        [SerializeField] protected GameObject _gameObjectToActivate;

        private bool _overWorldCamera = true;
        
        public override void Interact(Inventory inventory)
        {
            base.Interact(inventory);
            CheckIfInventoryHasKeyObject(inventory);
            SwitchCamera();
        }

        private void CheckIfInventoryHasKeyObject(Inventory inventory)
        {
            InventorySlot[] inventorySlots = inventory.GetInventorySlots();
            
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                if (inventorySlots[i].GetPickUp().gameObject.name == "EmptyInventorySlot")
                {
                    continue;
                }
                
                GameObject pickUp = inventorySlots[i].GetPickUp().gameObject;

                if (pickUp != _keyObject)
                {
                    continue;
                }
                _gameObjectToActivate.SetActive(true);
                return;
            }
        }

        void Update()
        {
            if (!_puzzle.GetCompleted()) return;
            gameObject.layer = 0;
        }

        public void SwitchCamera()
        {
            _cameraSwitcherAnimator.Play(_overWorldCamera ? PUZZLE_CAMERA_STATE : OVER_WORLD_CAMERA_STATE);
            _overWorldCamera = !_overWorldCamera;
        }

        public void ChangeZoomInState()
        {
            GameManager.Instance.SetZoomInState(!GameManager.Instance.IsInZoomInState());
        }
    }
}
