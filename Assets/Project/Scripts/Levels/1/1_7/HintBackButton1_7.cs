using Project.Scripts.Interactable.Static;
using UnityEngine;

namespace Project.Scripts.Levels._1._1._7 {

    public class HintBackButton1_7 : MonoBehaviour
    {

        [SerializeField] private UnlockableObject _door;
        
        public void OpenDoor() {
            _door.Unlock();
        }
    }

}