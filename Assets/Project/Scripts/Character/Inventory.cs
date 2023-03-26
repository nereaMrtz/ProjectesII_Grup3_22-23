using Project.Scripts.Interactable.PickUps;
using UnityEngine;

namespace Project.Scripts.Character {

    public class Inventory : MonoBehaviour
    {
        [SerializeField] private InventorySlot[] _inventorySlots;

        //private PickUp _firstPickUpSelected;

        private bool _itemSelected;

        private void Start()
        {
            _inventorySlots = new InventorySlot[7];

            for (int i = 0; i < transform.childCount; i++)
            {
                _inventorySlots[i] = gameObject.transform.GetChild(i).gameObject.GetComponent<InventorySlot>();
            }
        }

        public bool InsertPickUp(PickUp pickUp)
        {
            foreach (InventorySlot inventorySlot in _inventorySlots)
            {
                if (inventorySlot.GetPickUp().gameObject.name == "EmptyInventorySlot")
                {
                    inventorySlot.SetPickUp(pickUp);
                    return true;
                }
            }
            return false;
        }

        /*public void SelectItem(int inventorySlot)
        {
            if (_itemSelected)
            {
                
            }
            else
            {
                _firstPickUpSelected = _inventorySlots[inventorySlot].GetPickUp();
                _itemSelected = true;
            }
        }*/

        public InventorySlot[] GetInventorySlots()
        {
            return _inventorySlots;
        }
    }
}
    
