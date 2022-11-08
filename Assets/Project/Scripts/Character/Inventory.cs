using Project.Scripts.Interactable.PickUps;
using Project.Scripts.Interactable.Static.RequiredInventory;
using UnityEngine;

namespace Project.Scripts.Character {

    public class Inventory : MonoBehaviour
    {
        [SerializeField] private InventorySlot[] _inventorySlots;

        private void Start()
        {
            _inventorySlots = new InventorySlot[7];

            for (int i = 0; i < transform.childCount; i++)
            {
                _inventorySlots[i] = gameObject.transform.GetChild(i).gameObject.GetComponent<InventorySlot>();
            }
        }

        public bool InsertPickUp(RequiredInventoryInteractable pickUp)
        {
            foreach (InventorySlot inventorySlot in _inventorySlots)
            {
                if (inventorySlot.GetPickUp() == null)
                {
                    inventorySlot.SetPickUp(pickUp);
                    return true;
                }
            }
            return false;
        }

        public InventorySlot[] GetInventorySlots()
        {
            return _inventorySlots;
        }
    }
}
    
