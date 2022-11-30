using System.Collections;
using System.Collections.Generic;
using Project.Scripts.Interactable.Static;
using Project.Scripts.Managers;
using Project.Scripts.Sound;
using UnityEngine;

public class PiggyBank : UnlockableObject
{
    [SerializeField] private SpriteRenderer _piggyBank;
    [SerializeField] private SpriteRenderer _bill;
    protected override void Unlock(AudioManager audioManager) // Lo q pasara cuando el player tenga en el inventario el martillo
    {
        _piggyBank.sortingOrder = -2;
        _bill.sortingOrder = -1;
        _bill.gameObject.SetActive(true);
    }
}
