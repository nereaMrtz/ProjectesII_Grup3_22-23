using System;
using System.Collections;
using Project.Scripts.Interactable.Static;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1._1_17
{
    public class Door1_17 : MonoBehaviour
    {
        private const String TOC = "Toc";
        
        [SerializeField] private UnlockableObject _door;

        [SerializeField] private BoxCollider2D _boxCollider2D;

        private int _timesKnocked;

        private void OnMouseDown()
        {
            AudioManager.Instance.Play(TOC);
            _timesKnocked++;
            if (_timesKnocked == 1)
            {
                StartCoroutine(ResetKnockKnock());
            }
            else
            {
                StopAllCoroutines();
                if (_door.IsUnlocked())
                {
                    return;
                }
                _door.Unlock();
                Destroy(_boxCollider2D);
            }
        }

        private IEnumerator ResetKnockKnock()
        {
            yield return new WaitForSeconds(1);
            _timesKnocked = 0;
        }
    }
}
