using System;
using Project.Scripts.Interactable.Static.RequiredInventory.FromInventoryToWorldSpace;
using Project.Scripts.Managers;
using UnityEngine.SceneManagement;

namespace Project.Scripts.Puzzle
{
    public class Hook : PlacePickupOnWorldSpace
    {
        private const String STEPS_SOUND_CLIP_NAME = "Steps Sound";
        public override void ActivateBehaviour()
        {
            AudioManager.Instance.Pause(STEPS_SOUND_CLIP_NAME);
            SceneManager.LoadScene(3);
        }
    }
}
