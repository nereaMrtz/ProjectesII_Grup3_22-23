using Project.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorAfter2Buttons : MonoBehaviour
{
    [SerializeField] protected Animator _animator;

    [SerializeField] protected GameObject _button2;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            AudioManager.Instance.Play("PulsarBoton");
            _animator.SetTrigger("Press");
            _button2.SetActive(true);
        }
    }
}