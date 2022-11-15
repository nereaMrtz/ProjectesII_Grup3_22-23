using System;
using Project.Scripts.UI;
using UnityEngine;

namespace Project.Scripts.Interactable
{
    public abstract class InteractableScript : MonoBehaviour
    {
        [SerializeField] private bool _activateHover;

        private bool _onView;
        private void OnBecameVisible()
        {
            if (_activateHover)
            {
                if (!_onView)
                {
                    gameObject.GetComponent<HoverTip>().OnView();
                }
            }
        }

        private void OnBecameInvisible()
        {
            if (_activateHover)
            {
                if (_onView)
                {
                    gameObject.GetComponent<HoverTip>().OffView();
                }
            }
        }
    }
}
