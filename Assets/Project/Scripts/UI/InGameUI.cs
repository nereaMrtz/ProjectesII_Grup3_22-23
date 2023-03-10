using System;
using UnityEngine;

namespace Project.Scripts.UI
{
    public class InGameUI : MonoBehaviour
    {
        private const String PLAYERS_PREFS_MUTE = "Player Prefs Mute";

        private const string SHOW_INVENTORY = "ShowInventory";

        [SerializeField] private Animator _animator;

        [SerializeField] private GameObject _muteIcon;

        private bool onInventory = false;

        private void OnEnable()
        {
            bool mute = PlayerPrefs.GetInt(PLAYERS_PREFS_MUTE) == 1 ? true : false;

            _muteIcon.SetActive(mute);
        }

        public void ShowInventory()
        {
            if (onInventory == false)
            {
                _animator.SetBool(SHOW_INVENTORY, true);
                onInventory = true;
            }
            else
            {
                _animator.SetBool(SHOW_INVENTORY, false);
                onInventory = false;
            }
        }
    }
}
