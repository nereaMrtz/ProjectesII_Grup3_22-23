using Project.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenNote : MonoBehaviour
{
    //show in inspector, private
    [SerializeField] GameObject Nota;
    [SerializeField] Sprite SobreAbierto;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Nota.SetActive(true);

            gameObject.GetComponent<SpriteRenderer>().sprite=SobreAbierto;

            //pause game
            Time.timeScale = 0;
            GameManager.Instance.SetPause(true);

            //sonido
            //GetComponent<AudioSource>().Play();
            AudioManager.Instance.Play("hoja");

        }
    }
}
