using System.Collections;
using Project.Scripts.Interactable.Static;
using Project.Scripts.Managers;
using TMPro;
using UnityEngine;

public class muerte : MonoBehaviour
{
    [SerializeField] GameObject blanket;
    [SerializeField] GameObject blood;

    [SerializeField] AudioSource gun;
    [SerializeField] GameObject button;

    [SerializeField] SpriteRenderer player;
    [SerializeField] Animator playerNormal;
    [SerializeField] RuntimeAnimatorController[] playerGhost;
    [SerializeField] Sprite ghost;
    [SerializeField] UnlockableObject door;
    [SerializeField] private TextMeshProUGUI _text;
    
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
        _text.text = "51. Matate";
    }

    void ChangeScenario()
    {
        blood.SetActive(true);
        player.sprite = ghost;
        playerNormal.runtimeAnimatorController = playerGhost[0];
    }
}
