using System;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Level
{
    public class ScenarioManagerTrigger : MonoBehaviour
    {

        private const String PLAYER_LAYER = "Player";
        
        [SerializeField] private GameObject[] _gameObjectsToTrigger;

        [SerializeField] private ScenarioManager _scenarioManager;


        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer == LayerMask.NameToLayer(PLAYER_LAYER))
            {
                _scenarioManager.SwitchDrugSubjectElementsChangeProperty(_gameObjectsToTrigger);
            }
        }
    }
}

