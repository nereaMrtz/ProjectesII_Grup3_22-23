using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Project.Scripts.Managers;
using Project.Scripts.Character;


public class LightChange : MonoBehaviour
{
    [SerializeField] Image light;
    Color[] combination = new Color[5];
    [SerializeField] Animator activateLightButton;
    [SerializeField] Player player;

    Vector2 stopMoving = new Vector2(0f, 0f);
    

    private void Start()
    {
        combination[0] = new Color32(105, 62, 180, 255);
        combination[1] = Color.yellow;
        combination[2] = Color.green;
        combination[3] = new Color32(105, 62, 180, 255);
        combination[4] = new Color32(43, 119, 178, 255);
    }
    public void ChangeColors()
    {
        GameManager.Instance.SetZoomInState(true);
        StartCoroutine(Change());
        
    }

     IEnumerator Change()
    {
        for (int i = 0; i < combination.Length; i++)
        {
            light.color = combination[i];
            yield return new WaitForSeconds(1);
        }
        GameManager.Instance.SetZoomInState(false);
    }

    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.layer == 6)
        {
            AudioManager.Instance.Play("PulsarBoton");
            activateLightButton.SetTrigger("Press");
            ChangeColors();
        }

    }
    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.layer == 6)
        {
            AudioManager.Instance.Play("SoltarBoton");
            activateLightButton.SetTrigger("Press");
            
        }
    }
}
