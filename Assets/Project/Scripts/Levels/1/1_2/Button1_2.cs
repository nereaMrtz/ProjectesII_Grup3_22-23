using Project.Scripts.Levels._1._1._1;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Levels._1._1._2
{
    public class Button1_2 : Button1_1
    {

        private int _pressCounter;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (_pressCounter > 2)
            {
                return;
            }
            if (collider2D.gameObject.layer != LayerMask.NameToLayer(PLAYER_LAYER))
            {
                return;
            }

            _pressCounter++;
            if (_pressCounter == 3)
            {
                _door.Unlock();
            }
            PressButton();
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != LayerMask.NameToLayer(PLAYER_LAYER))
            {
                return;
            }

            _pressed = false;
            _animator.SetTrigger("Press");
        }
    }
}
