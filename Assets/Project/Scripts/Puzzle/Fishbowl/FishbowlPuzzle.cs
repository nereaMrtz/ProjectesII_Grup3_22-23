using UnityEngine;

namespace Project.Scripts.Puzzle.Fishbowl
{
    public class FishbowlPuzzle : PuzzleScript
    {
        [SerializeField] private Interactable.Static.RequiredInventory.Fishbowl _fishbowl;

        private void Update()
        {
            if (_fishbowl.GetFish().transform.childCount == 0)
            {
                _completed = true;
            }
        }
    }
}
