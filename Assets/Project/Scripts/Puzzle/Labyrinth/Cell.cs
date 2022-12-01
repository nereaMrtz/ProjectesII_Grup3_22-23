using Project.Scripts.NoMonoBehaviourClass;
using UnityEngine;

namespace Project.Scripts.Puzzle 
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private GameObject[] _nearCells;
    }
}