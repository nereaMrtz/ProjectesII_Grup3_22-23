using System.Collections;
using Project.Scripts.Interactable.Static;
using UnityEngine;

namespace Project.Scripts.Levels._1._1_17
{
    public class Door1_17 : MonoBehaviour
    {
        [SerializeField] private UnlockableObject _door;

        private int _timesKnocked;

        private void OnMouseDown()
        {
            _timesKnocked++;
            if (_timesKnocked == 1)
            {
                StartCoroutine(ResetKnockKnock());
            }
            else
            {
                StopAllCoroutines();
                if (_door.IsUnlocked())
                {return;
                    
                }
                _door.Unlock();
            }
        }

        private IEnumerator ResetKnockKnock()
        {
            yield return new WaitForSeconds(1);
            _timesKnocked = 0;
        }
    }
}
