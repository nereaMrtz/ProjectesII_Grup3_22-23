using System;
using UnityEngine;

namespace Project.Scripts.Menus
{
    public class SettingsMenu : MonoBehaviour
    {
        private const String SETTINGS_MENU_NAME = "Settings Menu";

        public void FullScreenToggle(bool fullScreen)
        {
            Screen.fullScreen = fullScreen;
        }
    }
}
