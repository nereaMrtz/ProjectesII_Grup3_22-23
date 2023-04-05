using Project.Scripts.Managers;
using UnityEngine;

public class OpenDoorAfter2Buttons : MonoBehaviour
{
    [SerializeField] protected Animator _animator;

    [SerializeField] protected GameObject _button2;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            AudioManager.Instance.Play("Press Button", gameObject);
            _animator.SetTrigger("Press");
            _button2.SetActive(true);
        }
    }
}