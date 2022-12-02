using Project.Scripts.NoMonoBehaviourClass;
using UnityEngine;

namespace Project.Scripts.Puzzle 
{
    public class Cell : MonoBehaviour
    {
        private const string LABYRINTH_CELL_LAYER = "LabyrinthCell";

        [SerializeField] private GameObject _upCell;
        [SerializeField] private GameObject _downCell;
        [SerializeField] private GameObject _rightCell;
        [SerializeField] private GameObject _leftCell;

        private string[] _directions = { "up", "down", "right", "left" };

        private void Start()
        {
            for (int i = 0; i < _directions.Length; i++)
            {
                LaunchRay(_directions[i]);
            }            
        }

        private void LaunchRay(string direction) 
        {
            Collider2D collider2D;
            switch (direction)
            {
                case "up":
                    collider2D = Physics2D.OverlapPoint(transform.position + Vector3.up * 0.09f, LayerMask.GetMask(LABYRINTH_CELL_LAYER));
                    if (collider2D.isTrigger)
                    {
                        _upCell = collider2D.gameObject;
                    }
                    break;

                case "down":
                    collider2D = Physics2D.OverlapPoint(transform.position + Vector3.down * 0.09f, LayerMask.GetMask(LABYRINTH_CELL_LAYER));
                    if (collider2D.isTrigger)
                    {
                        _downCell = collider2D.gameObject;
                    }
                    break;

                case "right":
                    collider2D = Physics2D.OverlapPoint(transform.position + Vector3.right * 0.09f, LayerMask.GetMask(LABYRINTH_CELL_LAYER));
                    if (collider2D.isTrigger)
                    {
                        _rightCell = collider2D.gameObject;
                    }
                    break;

                case "left":
                    collider2D = Physics2D.OverlapPoint(transform.position + Vector3.left * 0.09f, LayerMask.GetMask(LABYRINTH_CELL_LAYER));
                    if (collider2D.isTrigger)
                    {
                        _leftCell = collider2D.gameObject;
                    }
                    break;
            }
        }

    }
}