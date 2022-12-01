using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BiggerCircle : MonoBehaviour
{
    private const string SHOW_INVENTORY = "ShowInventory";
    [SerializeField] private GameObject bigCircle;
    [SerializeField] private Animator _animator;

    public void ActiveSmallCircle()
    {
        bigCircle.SetActive(!bigCircle.activeSelf);

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            ActiveSmallCircle();
            _animator.SetBool(SHOW_INVENTORY, true);

        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            ActiveSmallCircle();
            _animator.SetBool(SHOW_INVENTORY, false);
        }
    }
}
