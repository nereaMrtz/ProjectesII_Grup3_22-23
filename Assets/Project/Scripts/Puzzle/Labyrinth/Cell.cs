using System;
using UnityEngine;

namespace Project.Scripts.Puzzle.Labyrinth 
{
    public class Cell : MonoBehaviour
    {
        private const string LABYRINTH_CELL_LAYER = "LabyrinthCell";

        [SerializeField] private BoxCollider2D _boxCollider2D;

        [SerializeField] private Cell _upCell;
        [SerializeField] private Cell _downCell;
        [SerializeField] private Cell _rightCell;
        [SerializeField] private Cell _leftCell;

        private string[] _directions = { "up", "down", "right", "left" };

        private void Awake()
        {
            for (int i = 0; i < _directions.Length; i++)
            {
                LaunchRay(_directions[i]);
            }            
        }

        private void Start()
        {
            Destroy(_boxCollider2D);
        }

        private void LaunchRay(string direction) 
        {
            Collider2D collider2D;
            switch (direction)
            {
                case "up":
                    collider2D = Physics2D.OverlapPoint(transform.position + Vector3.up * 0.09f, LayerMask.GetMask(LABYRINTH_CELL_LAYER));
                    if (collider2D)
                    {
                        if (collider2D.isTrigger)
                        {
                            _upCell = collider2D.gameObject.GetComponent<Cell>();
                        }
                    }
                    break;

                case "down":
                    collider2D = Physics2D.OverlapPoint(transform.position + Vector3.down * 0.09f, LayerMask.GetMask(LABYRINTH_CELL_LAYER));
                    if (collider2D)
                    {
                        if (collider2D.isTrigger)
                        {
                            _downCell = collider2D.gameObject.GetComponent<Cell>();
                        }
                    }
                    break;

                case "right":
                    collider2D = Physics2D.OverlapPoint(transform.position + Vector3.right * 0.09f, LayerMask.GetMask(LABYRINTH_CELL_LAYER));
                    if (collider2D)
                    {
                        if (collider2D.isTrigger)
                        {
                            _rightCell = collider2D.gameObject.GetComponent<Cell>();
                        }
                    }
                    break;

                case "left":
                    collider2D = Physics2D.OverlapPoint(transform.position + Vector3.left * 0.09f, LayerMask.GetMask(LABYRINTH_CELL_LAYER));
                    if (collider2D)
                    {
                        if (collider2D.isTrigger)
                        {
                            _leftCell = collider2D.gameObject.GetComponent<Cell>();
                        }
                    }
                    break;
            }
        }

        public Cell GetUpCell()
        {
            return _upCell;
        }

        public Cell GetDownCell()
        {
            return _downCell;
        }

        public Cell GetRightCell()
        {
            return _rightCell;
        }

        public Cell GetLeftCell()
        {
            return _leftCell;
        }

    }
}