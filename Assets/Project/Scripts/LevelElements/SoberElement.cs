namespace Project.Scripts.Level
{
    public class SoberElement : DrugSubjectElement
    {
        public override void Accept()
        {
            _scenarioManager.Visit(this);
        }
    }
}