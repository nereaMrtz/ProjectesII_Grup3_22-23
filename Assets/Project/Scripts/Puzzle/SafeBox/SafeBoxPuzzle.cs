using Project.Scripts.Puzzle.Password;
using UnityEngine;

namespace Project.Scripts.Puzzle.SafeBox
{
    public class SafeBoxPuzzle : PasswordPuzzle
    {
        [SerializeField] private Interactable.Static.NotRequiredInventory.SafeBox _safeBox;

        //LLAMAREMOS ESTA FUNCION DES DEL ZOOM IN
        public void TryToOpen()
        {
            if (IsCorrectPassword("Parametro"))
            {
                _safeBox.Open();
            }
        }

    }
}
