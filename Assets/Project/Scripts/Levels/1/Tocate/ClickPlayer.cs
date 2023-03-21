using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Scripts.Interactable.Static;

public class ClickPlayer : MonoBehaviour
{
    [SerializeField] UnlockableObject door;

    private void OnMouseDown()
    {
        door.Unlock();
    }
}
