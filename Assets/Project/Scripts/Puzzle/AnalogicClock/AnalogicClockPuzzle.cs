using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Puzzle.AnalogicClock
{
    public class AnalogicClockPuzzle : PuzzleScript
    {
        [SerializeField] Transform minutes, hours;

        [SerializeField] private GameObject _hammer;
    
        private float _minMinutes = 175f;
        private float _maxMinutes = 185f;
        private float _minHours = 85f;
        private float _maxHours = 95f;

        void Update()
        {
            if ((Mathf.Abs(minutes.rotation.eulerAngles.z) >= _minMinutes && Mathf.Abs(minutes.rotation.eulerAngles.z) <= _maxMinutes) && 
                (Mathf.Abs(hours.rotation.eulerAngles.z) >= _minHours && Mathf.Abs(hours.rotation.eulerAngles.z) <= _maxHours))
            {
                _hammer.SetActive(true);

                _completed = true;
            }
        }
    }
}
