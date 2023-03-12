using Project.Scripts.Level;

namespace Project.Scripts.LevelElements
{
    public class DruggedElement : DrugSubjectElement
    {
        public override void Accept()
        {
            _scenarioManager.Visit(this);
        }
    }
}

