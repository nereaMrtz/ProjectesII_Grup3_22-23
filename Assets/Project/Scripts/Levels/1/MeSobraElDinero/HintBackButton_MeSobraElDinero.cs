using Project.Scripts.Interactable.Static;
using UnityEngine;

namespace Project.Scripts.Levels._1.MeSobraElDinero {

    public class HintBackButton_MeSobraElDinero : MonoBehaviour
    {

        [SerializeField] private UnlockableObject _door;
        
        public void OpenDoor() {
            
            if (_door.IsUnlocked())
            {
                return;    
            }
            _door.Unlock();
        }
    }

}