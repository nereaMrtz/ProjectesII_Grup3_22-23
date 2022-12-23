using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Level {
    public class ModifyUIButtonActiveSelf : MonoBehaviour
    {

        [SerializeField] private List<GameObject> _UIButtons = new List<GameObject>();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == 6)                
            {
                for (int i = 0; i < _UIButtons.Count; i++)
                {
                    _UIButtons[i].SetActive(true);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.layer == 6)
            {
                for (int i = 0; i < _UIButtons.Count; i++)
                {
                    _UIButtons[i].SetActive(false);
                }
            }
        }

        public void AddUIButton(GameObject UIBUtton)
        {
            _UIButtons.Add(UIBUtton);
        }

        public void RemoveUIButton(GameObject UIButton)
        {
            _UIButtons.Remove(UIButton);
        }
    }
}
