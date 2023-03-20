using Project.Scripts.Character;
using UnityEngine;

namespace Project.Scripts.Levels._1.LlevasUnaCopaDeMas
{
    public class Movement_LlevasUnaCopaDeMas : MonoBehaviour
    {
        [SerializeField] private Player _player;

        [SerializeField] private float _timeToChangeMoves;

        private float _currentTime;

        private void Start()
        {
            _currentTime = _timeToChangeMoves;
        }

        private void Update()
        {
            _currentTime -= Time.deltaTime;

            if (!(_currentTime <= 0))
            {
                return;
            }
            //_player.SetRandomAxis(Shuffle(_player.GetRandomAxis()));
            _currentTime = _timeToChangeMoves;
        }

        private int[] Shuffle(int[] array)
        {
            int[] auxArray = array;
            
            int auxValue;
            
            for (int i = 0; i < auxArray.Length - 1; i++)
            {
                int random = Random.Range(i, auxArray.Length);
                auxValue = auxArray[random];
                auxArray[random] = auxArray[i];
                auxArray[i] = auxValue;
            }

            return auxArray;
        }
    }
}
