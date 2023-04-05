using System;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1.LlevasUnaCopaDeMas
{
    public class Hiccup : MonoBehaviour
    {
        private const String HICCUP = "Hipo";
        
        private void Start()
        {
            AudioManager.Instance.Play(HICCUP, gameObject);
        }
    }
}
