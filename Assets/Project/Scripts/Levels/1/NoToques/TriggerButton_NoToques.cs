using System.Collections;
using UnityEngine;

namespace Project.Scripts.Levels._1.NoToques
{
    public class TriggerButton_NoToques : MonoBehaviour
    {
        private const int PLAYER_LAYER = 6;

        [SerializeField] private Button_NoToques _button;
        
        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer == PLAYER_LAYER)
            {
                StartCoroutine(AttractButton());
            }
        }

        private IEnumerator AttractButton()
        {
            while (Vector3.Distance(_button.transform.position, transform.position) > 0)
            {
                _button.transform.position = Vector3.MoveTowards(_button.transform.position, transform.position, Time.deltaTime * 10);
                yield return null;
            }
            
            Destroy(gameObject);
        }
    }
}
