using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Project.Scripts.Interactable.Static.NotRequiredInventory;
using Project.Scripts.Sound;

public class ZoomIn : NotRequiredInventoryInteractable
{

    [SerializeField] private GameObject Activate;

    public override void Interact(AudioManager audioManager)
    {
        Activate.SetActive(!Activate.activeSelf);
    }

}
