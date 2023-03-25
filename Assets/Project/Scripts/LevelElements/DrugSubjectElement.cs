using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Level
{
    public abstract class DrugSubjectElement : MonoBehaviour
    {
        [SerializeField] private bool _canChange;

        [SerializeField] protected ScenarioManager _scenarioManager;

        public bool GetCanChange()
        {
            return _canChange;
        }

        public void SetCanChange(bool canChange)
        {
            _canChange = canChange;
        }

        public abstract void Accept();
    } 
}

