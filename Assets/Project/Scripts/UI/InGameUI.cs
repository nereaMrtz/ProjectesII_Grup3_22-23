using System;
using Project.Scripts.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Project.Scripts.UI
{
    public class InGameUI : MonoBehaviour
    {
        private const String EXCLUDE_LEVEL = "MeSobraElDinero";
        private const String PLAYERS_PREFS_MASTER_MUTE = "Player Prefs Master Mute";
        private const String PLAYERS_PREFS_SFX_MUTE = "Player Prefs SFX Mute";
        private const String PLAYERS_PREFS_MUSIC_MUTE = "Player Prefs Music Mute";
        private const String SHOW_INVENTORY = "ShowInventory";

        [SerializeField] private Animator _animator;

        [SerializeField] private GameObject _masterMuteIcon;

        [SerializeField] private TextMeshProUGUI _hintCoinsMarker;

        private bool onInventory;

        private void OnEnable()
        {
            if (SceneManager.GetActiveScene().name == EXCLUDE_LEVEL)
            {
                _hintCoinsMarker.text = "999";
            }
            else
            {
                UpdateCoinsMarker();    
            }

            bool masterMute = PlayerPrefs.GetInt(PLAYERS_PREFS_MASTER_MUTE) == 1;
            bool SFXMute = PlayerPrefs.GetInt(PLAYERS_PREFS_SFX_MUTE) == 1;
            bool musicMute = PlayerPrefs.GetInt(PLAYERS_PREFS_MUSIC_MUTE) == 1;

            _masterMuteIcon.SetActive(masterMute);
        }

        public void UpdateCoinsMarker()
        {
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
