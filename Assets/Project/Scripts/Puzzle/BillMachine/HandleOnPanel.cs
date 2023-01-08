using System;
using System.Collections;
using Project.Scripts.Interactable.Static.NotRequiredInventory;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Puzzle.BillMachine
{
    public class HandleOnPanel: NotRequiredInventoryInteractable
    {
        private const String HANDLE_SOUND = "Palanca";
        
        [SerializeField] private GameObject _machine;
        [SerializeField] private Animator _handlerAnimator;
        public override void Interact()
        {
            AudioManager.Instance.Play(HANDLE_SOUND);
            _handlerAnimator.enabled = true;

            StartCoroutine(ActivateMachine(_handlerAnimator.runtimeAnimatorController.animationClips[0]));
        }

        private IEnumerator ActivateMachine(AnimationClip time)
        {
            yield return new WaitForSeconds(time.length);
            
            _machine.layer = LayerMask.NameToLayer("RequiredInventoryInteractable");
        }
    }
}