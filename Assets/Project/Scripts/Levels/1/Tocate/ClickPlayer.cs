using Project.Scripts.Interactable.Static;
using UnityEngine;

namespace Project.Scripts.Levels._1.Tocate
{
    public class ClickPlayer : MonoBehaviour
    {
        [SerializeField] UnlockableObject door;

        private void OnMouseDown()
        {
            door.Unlock();
        }
    }
}
