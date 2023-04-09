using System;
using Project.Scripts.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.UI
{
    public class InGameUI : MonoBehaviour
    {
        private const String EXCLUDE_LEVEL = "MeSobraElDinero";
        private const String PLAYERS_PREFS_MASTER_MUTE = "Player Prefs Master Mute";
        private const String PLAYERS_PREFS_SFX_MUTE = "Player Prefs SFX Mute";
        private const String PLAYERS_PREFS_MUSIC_MUTE = "Player Prefs Music Mute";
        private const String COIN_SPRITE_CODE = "<sprite=0>";
        private const String BOTON_MENU = "BotonMenu";

        [SerializeField] private GameObject _masterMuteIcon;
        /*[SerializeField] private GameObject _SFXMuteIcon;
        [SerializeField] private GameObject _musicMuteIcon;*/

        [SerializeField] private TextMeshProUGUI _hintCoinsMarker;

        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
            AudioManager.Instance.SetAudioSourceComponent(_audioSource, BOTON_MENU);
        }

        private void OnEnable()
        {
            if (SceneManager.GetActiveScene().name == EXCLUDE_LEVEL)
            {
                _hintCoinsMarker.text = "999" + COIN_SPRITE_CODE;
            }
            else
            {
                UpdateCoinsMarker();    
            }

            bool masterMute = PlayerPrefs.GetInt(PLAYERS_PREFS_MASTER_MUTE) == 1;
            bool SFXMute = PlayerPrefs.GetInt(PLAYERS_PREFS_SFX_MUTE) == 1;
            bool musicMute = PlayerPrefs.GetInt(PLAYERS_PREFS_MUSIC_MUTE) == 1;

            _masterMuteIcon.SetActive(masterMute);
            //_SFXMuteIcon.SetActive(SFXMute);
            //_musicMuteIcon.SetActive(musicMute);
        }

        public void UpdateCoinsMarker()
        {
            _hintCoinsMarker.text = GameManager.Instance.GetHintCoins() + COIN_SPRITE_CODE;
        }

        public void PlaySoundUIButton()
        {
            _audioSource.Play();
        }

        public void SetPause()
        {
            GameManager.Instance.SetPause(true);
        }
    }
}
