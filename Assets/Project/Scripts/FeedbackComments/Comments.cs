using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Project.Scripts.Interactable.Static.NotRequiredInventory;
using Project.Scripts.Sound;
using TMPro;

public class Comments : NotRequiredInventoryInteractable
{
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private string text;
   
   
    public override void Interact(AudioManager audioManager)
    {
        dialogBox.SetActive(!dialogBox.activeSelf);

    }
}
