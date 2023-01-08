using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    private const string SHOW_INVENTORY = "ShowInventory";
    [SerializeField] private Animator _animator;
    private bool onInventory = false;

    public void ShowInventory()
    {
        if (onInventory == false)
        {
            _animator.SetBool(SHOW_INVENTORY, true);
            onInventory = true;
        }
        else
        {
            _animator.SetBool(SHOW_INVENTORY, false);
            onInventory = false;
        }
    }
}
