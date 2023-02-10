using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarSala : MonoBehaviour
{
    [SerializeField] protected int _sala;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            SceneManager.LoadScene(_sala);
    }
}
