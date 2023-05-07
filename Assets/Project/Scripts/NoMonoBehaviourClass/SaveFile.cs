using System;

namespace Project.Scripts.NoMonoBehaviourClass
{
    [Serializable]
    
    public class SaveFile
    {
        public bool[] levelsWhereHintUsed;
        public bool[] levelsWhereHintTaken;
        
        public int levelsCompleted;
        public int coins;
    }
}
