using System;
using Project.Scripts.ProjectMaths;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.UI
{
    public class Brightness : MonoBehaviour
    {
        private const String PLAYER_PREFS_BRIGHTNESS = "Player Prefs Brightness";
        
        [SerializeField] private Image _image;

        private void OnEnable()
        {
            Color auxColor = _image.color;
            auxColor.a = CustomMath.Map(PlayerPrefs.GetFloat(PLAYER_PREFS_BRIGHTNESS), 0, 1, 1, 0);
            _image.color = auxColor;
        }
    }
}
