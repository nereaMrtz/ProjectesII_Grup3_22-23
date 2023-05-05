using System;
using Project.Scripts.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.NoMonoBehaviourClass
{
    [Serializable]
    
    public class SaveFile
    {
        public bool[] levelsWhereHintUsed;
        public bool[] levelsWhereHintTaken;

        public float brightness;

        public int levelsCompleted;
        public int coins;
    }
}
