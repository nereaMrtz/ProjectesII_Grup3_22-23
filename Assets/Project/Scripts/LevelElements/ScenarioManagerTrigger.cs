using System;
using UnityEngine;

namespace Project.Scripts.Level
{
    public class ScenarioManagerTrigger : DrugSubjectElement
    {

        private const String PLAYER_LAYER = "Player";
        
        [SerializeField] private GameObject[] _gameObjectsToTrigger;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer == LayerMask.NameToLayer(PLAYER_LAYER))
            {
                _scenarioManager.SwitchDrugSubjectElementsChangeProperty(_gameObjectsToTrigger);
                SetCanChange(false);
                gameObject.SetActive(false);
            }
        }

        public override void Accept()
        {
            _scenarioManager.Visit(this);
        }
    }
}

