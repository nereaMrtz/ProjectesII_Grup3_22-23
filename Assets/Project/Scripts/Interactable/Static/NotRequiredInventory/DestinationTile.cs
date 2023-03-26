using Project.Scripts.Puzzle.CrossCardinalDirections;
using UnityEngine;

namespace Project.Scripts.Interactable.Static.NotRequiredInventory
{
    public class DestinationTile : NotRequiredInventoryInteractable
    {
        [SerializeField] private GameObject _reward;

        private PressurePoint _pressurePoint;

        private bool _puzzleCompleted;

        private void Start()
        {
            _pressurePoint = gameObject.GetComponent<PressurePoint>();
        }

        public override void Interact()
        {
            if (_puzzleCompleted)
            {
                _reward.transform.position = transform.position;
                _reward.SetActive(true);
                StartCoroutine(_pressurePoint.ChangeColor(_pressurePoint.GetColor()));
                gameObject.layer = 0;
            }            
        }

        public void SetPuzzleCompleted(bool puzzleCompleted)
        {
            _puzzleCompleted = puzzleCompleted;
        }
    } 
}

