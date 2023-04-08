using System;
using System.Collections;
using Project.Scripts.Levels._1.Logico;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1.Matalo
{
    public class Button_Matalo : Button_Logico
    {

        [SerializeField] private CapsuleCollider2D _capsuleCollider2D;

        [SerializeField] private GameObject _chain;

        private int _pressCounter;

        private float _delayTime;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }

            switch (_pressCounter)
            {
                case 0:
                    StartCoroutine(GetDownBlanket());
                    break;
                
                case 1:
                    RemoveBlanket();
                    break;
                
                case 2:
                    KillBaby();
                    break;
                
                case 3:
                    RevealExit();
                    break;
            }

            StartCoroutine(DisableCapsuleCollider());
        }

        private IEnumerator GetDownBlanket()
        {
            _capsuleCollider2D.enabled = false;
            while (_chain.transform.position.y > 3.33f)
            {
                _chain.transform.position =
                    Vector2.MoveTowards(_chain.transform.position, new Vector2(_chain.transform.position.x, 3.33f), Time.deltaTime);

                yield return null;
            }

            _capsuleCollider2D.enabled = true;

            _pressCounter++;
        }

        private void RemoveBlanket()
        {
            
        }

        private void KillBaby()
        {
            
        }

        private void RevealExit()
        {
            
        }

        private IEnumerator DisableCapsuleCollider()
        {
            _capsuleCollider2D.enabled = false;
            yield return new WaitForSeconds(_delayTime);
            _capsuleCollider2D.enabled = true;
        }
    }
}
