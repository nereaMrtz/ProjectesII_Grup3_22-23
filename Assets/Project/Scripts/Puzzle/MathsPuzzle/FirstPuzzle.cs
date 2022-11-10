using Project.Scripts.Puzzle.Password;
using UnityEngine;

namespace Project.Scripts.Puzzle.MathsPuzzle
{
    public class FirstPuzzle : PasswordPuzzle
    {
        [SerializeField] private GameObject prueba;
        public void CheckAnswer(string answer)
        {
            int aux = int.Parse(answer);

            if (aux == 11)
            {
                _completed = true;
            }
        }
    }
}
