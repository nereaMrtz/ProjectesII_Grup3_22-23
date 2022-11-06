using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Project.Scripts.Interactable.Static.NotRequiredInventory;

public class ZoomIn : NotRequiredInventoryInteractable
{

    [SerializeField] private GameObject Activate;

    public override void Interact()
    {
        Activate.SetActive(!Activate.activeSelf);
    }

}
