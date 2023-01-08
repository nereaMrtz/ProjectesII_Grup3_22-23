using System;
using System.Collections;
using System.Collections.Generic;
using Project.Scripts.Level;
using UnityEngine;

namespace Project.Scripts.Managers
{
    public class ScenarioManager : MonoBehaviour
    {
        private const String THROW_UP_SOUND_CLIP_NAME = "Throw Up Sound";
        private const String TAKE_THIS_PILL_SOUND_CLIP_NAME = "Take This Pill Sound";

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
            StartCoroutine(_drugged
                ? DelayChange(AudioManager.Instance.ClipDuration(THROW_UP_SOUND_CLIP_NAME))
                : DelayChange(AudioManager.Instance.ClipDuration(TAKE_THIS_PILL_SOUND_CLIP_NAME)));
        }

        public void SwitchDrugSubjectElementsChangeProperty(GameObject[] drugSubjectElementsToChangePropertyChange)
        {
            for (int i = 0; i < drugSubjectElementsToChangePropertyChange.Length; i++)
            {
                DrugSubjectElement drugSubjectElement = drugSubjectElementsToChangePropertyChange[i].GetComponent<DrugSubjectElement>();
                drugSubjectElement.Accept();
            }
        }

        public void Visit(ScenarioManagerTrigger scenarioManagerTrigger)
        {
            scenarioManagerTrigger.SetCanChange(!scenarioManagerTrigger.GetCanChange());
        }

        public void Visit(DruggedElement druggedElement)
        {
            druggedElement.SetCanChange(!druggedElement.GetCanChange());
        }

        public void Visit(SoberElement soberElement)
        {
            soberElement.SetCanChange(!soberElement.GetCanChange());
        }

        private IEnumerator DelayChange(float time)
        {
            yield return new WaitForSeconds(time / 2);
            ActivateOrDeactivateDrugSubjectElementsGameObjects(_druggedElements, _drugged);
            ActivateOrDeactivateDrugSubjectElementsGameObjects(_soberElements, !_drugged);
            ActivateOrDeactivateScenarioManagerTriggersGameObjects();
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

