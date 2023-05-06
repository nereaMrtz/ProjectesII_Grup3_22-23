using Project.Scripts.Interactable.Static;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using Unity.VisualScripting;
using UnityEngine;

public class muerte : MonoBehaviour
{
    [SerializeField] GameObject blanket;
    [SerializeField] GameObject blood;

    [SerializeField] AudioSource gun;
    [SerializeField] GameObject button;

    [SerializeField] SpriteRenderer player;
    [SerializeField] Sprite ghost;
    [SerializeField] UnlockableObject door;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 6)
        StartCoroutine(Blanket());
    }

    IEnumerator Blanket()
    {
        blanket.SetActive(true);
        gun.Play();
        yield return new WaitForSeconds(3);
        Destroy(button);
        door.Unlock();
        ChangeScenario();
        blanket.SetActive(false);
    }

    void ChangeScenario()
    {
        blood.SetActive(true);
        player.sprite = ghost;
    }
}
