using System.Collections;
using UnityEngine;

namespace Project.Scripts.Puzzle.Labyrinth
{
    public class ObjectGoingThroughMaze : MonoBehaviour
    {
        [SerializeField] private Cell _startCell;
        [SerializeField] private Cell _endCell;
        
        private Cell _currentCell;
        private Cell _intendedCell;
        
        private bool _move;
        
        // Start is called before the first frame update
        void Start()
        {
            _move = true;
            _currentCell = _startCell;
        }

        // Update is called once per frame
        void Update()
        {
            if (_move)
            {
                Controls();    
            }
        }

        public bool CheckEndCell()
        {
            return _currentCell == _endCell;
        }

        private void Controls()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                _intendedCell = _currentCell.GetUpCell();
                if (_intendedCell != null)
                {
                    Debug.Log("Hola1");
                    StartCoroutine(MoveObject(_intendedCell.gameObject.transform.position));
                }
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                _intendedCell = _currentCell.GetLeftCell();
                if (_intendedCell != null)
                {
                    Debug.Log("Hola2");
                    StartCoroutine(MoveObject(_intendedCell.gameObject.transform.position));
                }
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                _intendedCell = _currentCell.GetRightCell();
                if (_intendedCell != null)
                {
                    Debug.Log("Hola3");
                    StartCoroutine(MoveObject(_intendedCell.gameObject.transform.position));
                }
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                _intendedCell = _currentCell.GetDownCell();
                if (_intendedCell != null)
                {
                    Debug.Log("Hola4");
                    StartCoroutine(MoveObject(_intendedCell.gameObject.transform.position));
                }
            }
        }

        private IEnumerator MoveObject(Vector3 targetPosition)
        {
            _move = false;
            while (Vector3.Distance(transform.position, targetPosition) > 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime);
                yield return null;
            }
            _currentCell = _intendedCell;
            _move = true;
        }
    }
}
