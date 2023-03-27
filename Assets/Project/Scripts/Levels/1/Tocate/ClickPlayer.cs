using Project.Scripts.Interactable.Static;
using UnityEngine;

public class ClickPlayer : MonoBehaviour
{
    [SerializeField] UnlockableObject door;

    private void OnMouseDown()
    {
        door.Unlock(0.1f);
    }
}
