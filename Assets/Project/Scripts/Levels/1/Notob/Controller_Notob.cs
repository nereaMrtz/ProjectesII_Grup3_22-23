using Project.Scripts.Levels._1.Logico;
using UnityEngine;

namespace Project.Scripts.Levels._1.Notob
{
    public class Controller_Notob : MonoBehaviour
    {
        [SerializeField] private Letter_Notob[] _letters;

        [SerializeField] private Button_Logico _button;

        private bool _letterClicked;

        public bool IsLetterClicked()
        {
            return _letterClicked;
        }

        public void SetLetterClicked(bool letterClicked)
        {
            _letterClicked = letterClicked;
        }
    }
}
