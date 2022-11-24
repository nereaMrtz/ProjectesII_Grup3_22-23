using Project.Scripts.Puzzle.Password;
using UnityEngine;
using Project.Scripts.FeedbackCircle;

namespace Project.Scripts.Puzzle.MathsPuzzle {

        public class FirstPuzzle : PasswordPuzzle
        {
            [SerializeField] private GameObject prueba;
            [SerializeField] private BoxCollider2D disableCollider;
            [SerializeField] private GameObject endPuzzle;
            [SerializeField] private Circle circle;
            public void CheckAnswer(string answer)
            {
                int aux = int.Parse(answer);

                if (aux == 11)
                {
                    _completed = true;
                    disableCollider.enabled = false;
                    circle.EndCircle();
                    endPuzzle.SetActive(false);

                }
            }
        }
    
}
