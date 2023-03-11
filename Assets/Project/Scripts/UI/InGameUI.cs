using System;
using Project.Scripts.Managers;
using TMPro;
using UnityEngine;

namespace Project.Scripts.UI
{
    public class InGameUI : MonoBehaviour
    {
        private const String PLAYERS_PREFS_MUTE = "Player Prefs Mute";

        private const string SHOW_INVENTORY = "ShowInventory";

        [SerializeField] private Animator _animator;

        [SerializeField] private GameObject _muteIcon;

        [SerializeField] private TextMeshProUGUI _hintCoinsMarker;

        private bool onInventory;

        private void OnEnable()
        {
            UpdateCoinsMarker();
            
            bool mute = PlayerPrefs.GetInt(PLAYERS_PREFS_MUTE) == 1;

            _muteIcon.SetActive(mute);
        }

        public void UpdateCoinsMarker()
        {
            Debug.Log(GameManager.Instance.GetHintCoins());
            _hintCoinsMarker.text = GameManager.Instance.GetHintCoins().ToString();
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
