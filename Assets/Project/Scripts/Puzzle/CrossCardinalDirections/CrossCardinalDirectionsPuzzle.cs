using System;
using System.Collections;
using Project.Scripts.Interactable.Static.NotRequiredInventory;
using Project.Scripts.NoMonoBehaviourClass;
using UnityEngine;

namespace Project.Scripts.Puzzle.CrossCardinalDirections
{
    public class CrossCardinalDirectionsPuzzle : PuzzleScript
    {
        [SerializeField] private Interactable.Static.NotRequiredInventory.Compass _compass;
        
        [SerializeField] private GameObject _initialTile;
        [SerializeField] private GameObject _cross;
        [SerializeField] private GameObject _pressurePointPrefab;
        
        [SerializeField] private DestinationTile _destinationTile;

        [SerializeField] private PressurePoint[] _pressurePoints;

        private int _pressureCounter;

        private Vector3 _offset;

        private void Start()
        {
            Direction[] directions = _compass.GetDirections();
            _offset = _initialTile.transform.position;
            _pressurePoints = new PressurePoint[directions.Length + 1];
            _pressurePoints[0] = _initialTile.GetComponent<PressurePoint>();
            for (int i = 1; i < _pressurePoints.Length - 1; i++)
            {
                _pressurePoints[i] = Instantiate(_pressurePointPrefab, transform).GetComponent<PressurePoint>();
                _pressurePoints[i].transform.position = _offset + directions[i - 1].GetVector();
                _offset = _pressurePoints[i].transform.position;
            }
            _pressurePoints[^1] = _destinationTile.GetComponent<PressurePoint>();
            _pressurePoints[^1].transform.position = _offset + directions[^1].GetVector();
        }

        private void Update()
        {
            if (_initialTile.activeSelf && !_completed)
            {
                CheckPressurePoints();
            }
        }

        private void CheckPressurePoints()
        {
            for (int i = 0; i < _pressurePoints.Length; i++)
            {
                PressurePoint pressurePoint = _pressurePoints[i];
                if (i < _pressureCounter)
                {
                    if (pressurePoint.IsBack())
                    {
                        IncorrectPressurePoint(_pressureCounter);
                        pressurePoint.SetBack(false);
                    }
                }
                else
                {
                    if (pressurePoint.IsChecked())
                    {
                        if (i != _pressureCounter)
                        {
                            IncorrectPressurePoint(i);
                        }
                        else
                        {
                            CorrectPressurePoint();
                        }
                    }
                }
            }
        }

        private void IncorrectPressurePoint(int currentPressurePoint)
        {
            _pressurePoints[currentPressurePoint].SetCheck(false);
            for (int j = 0; j < _pressureCounter; j++)
            {
                PressurePoint pressurePoint = _pressurePoints[j];
                pressurePoint.SetCheck(false);
                StartCoroutine(pressurePoint.ChangeColor(pressurePoint.GetColor()));
            }
            _pressureCounter = 0;
        }

        private void CorrectPressurePoint()
        {
            _pressurePoints[_pressureCounter].SetCheck(true);
            if (_pressureCounter + 1 != _pressurePoints.Length)
            {
                StartCoroutine(_pressurePoints[_pressureCounter].ChangeColor(new Color(0.54f, 0.54f, 0.54f)));  
            }
            _pressureCounter++;

            if (_pressureCounter == _pressurePoints.Length)
            {
                for (int i = 0; i < _pressurePoints.Length - 1; i++)
                {
                    PressurePoint pressurePoint = _pressurePoints[i];
                    pressurePoint.SetCheck(false);
                    StartCoroutine(pressurePoint.ChangeColor(pressurePoint.GetColor()));
                }

                StartCoroutine(_pressurePoints[_pressureCounter - 1].ChangeColor(new Color(1, 1, 1)));
                _destinationTile.SetPuzzleCompleted(true);
                _completed = true;
            }
        }

        public override void Unlock()
        {
            _initialTile.SetActive(true);
            _cross.SetActive(true);
            _destinationTile.gameObject.SetActive(true);
            for (int i = 0; i < _pressurePoints.Length; i++)
            {
                _pressurePoints[i].gameObject.SetActive(true);
            }
        }
    }
}

