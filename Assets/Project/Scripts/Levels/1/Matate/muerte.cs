using Project.Scripts.Interactable.Static;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using Project.Scripts.Managers;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class muerte : MonoBehaviour
{
    [SerializeField] GameObject blanket;
    [SerializeField] GameObject blood;

    [SerializeField] AudioSource gun;
    [SerializeField] GameObject button;

    [SerializeField] SpriteRenderer player;
    [SerializeField] Animator playerNormal;
    [SerializeField] AnimatorController playerGhost;
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
        GameManager.Instance.SetFading(true);
        yield return new WaitForSeconds(3);
        GameManager.Instance.SetFading(false);
        Destroy(button);
        door.Unlock();
        ChangeScenario();
        blanket.SetActive(false);
        GameManager.Instance.SetGhost(true);
    }

    void ChangeScenario()
    {
        blood.SetActive(true);
        player.sprite = ghost;
        playerNormal.runtimeAnimatorController = playerGhost;
    }
}
