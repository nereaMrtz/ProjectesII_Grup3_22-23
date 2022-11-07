using UnityEngine;

namespace Project.Scripts.Level
{
    public class DruggedElement : DrugSubjectElement
    {
        public override void Accept(DrugSubjectElement drugSubjectElement)
        {
            _scenarioManager.Visit(this, drugSubjectElement);
        }
    }
}

