using Project.Scripts.Interactable.Static;
using UnityEngine;

namespace Project.Scripts.Levels._1.Shhhh
{
    public class DeafenYourself : MonoBehaviour
    {
        [SerializeField] private UnlockableObject _door;

        private void OnEnable()
        {
            if (_door.IsUnlocked())
            {
                return;
            }
            _door.Unlock(0.1f);
        }
    }
}
