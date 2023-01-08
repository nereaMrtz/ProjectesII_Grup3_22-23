using UnityEngine;

namespace Project.Scripts.Level
{
    public class DruggedElement : DrugSubjectElement
    {
        public override void Accept()
        {
            _scenarioManager.Visit(this);
        }
    }
}

