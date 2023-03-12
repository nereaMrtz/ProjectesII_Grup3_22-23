using System;
using UnityEngine;

namespace Project.Scripts.Levels._1.SeparadosAlNacer
{
    public class ElectricityPanel_SeparadosAlNacer : MonoBehaviour
    {

        [SerializeField] private float _timeWhenClick;

        private void OnMouseEnter()
        {
            if (!Input.GetMouseButton(0))
            {
                return;
            }
            _timeWhenClick = Time.time;
        }

        private void OnMouseDown()
        {
            _timeWhenClick = Time.time;
        }

        public float GetTime()
        {
            return _timeWhenClick;
        }
    }
}
