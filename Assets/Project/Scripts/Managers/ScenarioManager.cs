using System;
using System.Collections.Generic;
using Project.Scripts.Level;
using UnityEngine;

namespace Project.Scripts.Managers
{
    public class ScenarioManager : MonoBehaviour
    {

        [SerializeField] private DrugSubjectElement[] _druggedElements;
        [SerializeField] private DrugSubjectElement[] _soberElements;

        [SerializeField] private List<ScenarioManagerTrigger> _scenarioManagerTriggers;

        private bool _drugged;

        private void Start()
        {
            _drugged = GameManager.Instance.IsDrugged();
        }

        private void Update()
        {
            if (_drugged == GameManager.Instance.IsDrugged())
            {
                return;
            }
            _drugged = !_drugged;
            ActivateOrDeactivateDrugSubjectElementsGameObjects(_druggedElements, _drugged);
            ActivateOrDeactivateDrugSubjectElementsGameObjects(_soberElements, !_drugged);
            ActivateOrDeactivateScenarioManagerTriggersGameObjects();
        }

        public void SwitchDrugSubjectElementsChangeProperty(GameObject[] drugSubjectElementsToChangePropertyChange)
        {
            for (int i = 0; i < drugSubjectElementsToChangePropertyChange.Length; i++)
            {
                DrugSubjectElement drugSubjectElement = drugSubjectElementsToChangePropertyChange[i].GetComponent<DrugSubjectElement>();
                drugSubjectElement.Accept(drugSubjectElement);
            }
        }

        public void Visit(ScenarioManagerTrigger scenarioManagerTrigger, DrugSubjectElement drugSubjectElementsToChangePropertyChange)
        {
            for (int j = 0; j < _scenarioManagerTriggers.Count; j++)
            {
                if (drugSubjectElementsToChangePropertyChange == _scenarioManagerTriggers[j])
                {
                    scenarioManagerTrigger.SetCanChange(!scenarioManagerTrigger.GetCanChange());
                    j = _scenarioManagerTriggers.Count;
                }
            }
        }

        public void Visit(DruggedElement druggedElement, DrugSubjectElement drugSubjectElementsToChangePropertyChange)
        {
            for (int j = 0; j < _druggedElements.Length; j++)
            {
                if (drugSubjectElementsToChangePropertyChange == _druggedElements[j])
                {
                    druggedElement.SetCanChange(!druggedElement.GetCanChange());
                    j = _druggedElements.Length;
                }
            }
        }

        public void Visit(SoberElement soberElement, DrugSubjectElement drugSubjectElementsToChangePropertyChange)
        {
            for (int j = 0; j < _soberElements.Length; j++)
            {
                if (drugSubjectElementsToChangePropertyChange == _soberElements[j])
                {
                    soberElement.SetCanChange(!soberElement.GetCanChange());
                    j = _soberElements.Length;
                }
            }
        }
        
        private void ActivateOrDeactivateDrugSubjectElementsGameObjects(DrugSubjectElement[] drugSubjectElements, bool drugged)
        {
            for (int i = 0; i < drugSubjectElements.Length; i++)
            {
                DrugSubjectElement drugSubjectElement = drugSubjectElements[i];
                if (drugSubjectElement.GetCanChange())
                {
                    drugSubjectElement.gameObject.SetActive(drugged);    
                }
            }
        }

        private void ActivateOrDeactivateScenarioManagerTriggersGameObjects()
        {
            for (int i = 0; i < _scenarioManagerTriggers.Count; i++)
            {
                ScenarioManagerTrigger scenarioManagerTrigger = _scenarioManagerTriggers[i];
                if (scenarioManagerTrigger.GetCanChange())
                {
                    scenarioManagerTrigger.gameObject.SetActive(!scenarioManagerTrigger.gameObject.activeSelf);
                }
            }
        }
    }
}

