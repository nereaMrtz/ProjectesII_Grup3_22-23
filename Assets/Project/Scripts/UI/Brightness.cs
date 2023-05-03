using System;
using System.Collections;
using Project.Scripts.Managers;
using Project.Scripts.ProjectMaths;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.UI
{
    public class Brightness : MonoBehaviour
    {
        [SerializeField] private Image _image;

        private void OnEnable()
        {
            Color auxColor = _image.color;
            auxColor.a = CustomMath.Map(GameManager.Instance.GetBrightness(), 0, 1, 0.85f, 0);
            _image.color = auxColor;
        }
    }
}
