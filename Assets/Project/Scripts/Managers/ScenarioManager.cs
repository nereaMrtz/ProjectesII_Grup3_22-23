using System;
using Project.Scripts.Level;
using UnityEngine;

namespace Project.Scripts.Managers
{
    public class ScenarioManager : MonoBehaviour
    {

        [SerializeField] private DrugSubjectElement[] _druggedElements;
        [SerializeField] private DrugSubjectElement[] _soberElements;

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
            ActivateOrDeactivateDrugSubjectElementsGameObjects();
        }

        public void SwitchDrugSubjectElementsChangeProperty(GameObject[] drugSubjectElements)
        {
            for (int i = 0; i < drugSubjectElements.Length; i++)
            {
                bool founded = false;
                
                for (int j = 0; j < _druggedElements.Length; j++)
                {
                    if (drugSubjectElements[i] == _druggedElements[j].gameObject)
                    {
                        DrugSubjectElement drugSubjectElement = _druggedElements[j];
                        drugSubjectElement.SetCanChange(!drugSubjectElement.GetCanChange());
                        founded = true;
                        j = _druggedElements.Length;
                    }
                }

                if (founded)
                {
                    continue;
                }

                for (int j = 0; j < _soberElements.Length; j++)
                {
                    if (drugSubjectElements[i] == _soberElements[j].gameObject)
                    {
                        DrugSubjectElement drugSubjectElement = _soberElements[j];
                        drugSubjectElement.SetCanChange(!drugSubjectElement.GetCanChange());
                        j = _soberElements.Length;
                    }
                }
            }
        }


        private void ActivateOrDeactivateDrugSubjectElementsGameObjects()
        {
            ActivateOrDeactivateGameObjects(_druggedElements, _drugged);
            ActivateOrDeactivateGameObjects(_soberElements, !_drugged);
        }

        private void ActivateOrDeactivateGameObjects(DrugSubjectElement[] drugSubjectElements, bool drugged)
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
    }
}

