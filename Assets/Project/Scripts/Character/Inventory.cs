using UnityEngine;

namespace Project.Scripts.Character {

    public class Inventory : MonoBehaviour
    { 
    
        private GameObject[] _inventoryPickUps;

        private void Start()
        {
            _inventoryPickUps = new GameObject[7];

            for (int i = 0; i < transform.childCount; i++)
            {
                _inventoryPickUps[i] = gameObject.transform.GetChild(i).gameObject;
            }
        }

        void InsertPickUp(GameObject pickUp) {

            for (int i = 0; i < _inventoryPickUps.Length; i++)
            {
                if (_inventoryPickUps[i] == null)
                {
                    _inventoryPickUps[i] = pickUp;
                }
            }        
        }    
    }
}
    
