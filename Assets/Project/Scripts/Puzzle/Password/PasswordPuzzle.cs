using System;
using UnityEngine;

namespace Project.Scripts.Puzzle.Password
{
    public class PasswordPuzzle : PuzzleScript
    {
        [SerializeField] private GameObject _physicalPanel;
        
        [SerializeField] private String _correctPassword;
        
        private String _writtenPassword;


        private void SetWrittenPassword(String writtenPassword)
        {
            //Pass int to string
            //int i = 10;
            //String j;
            //j = i.ToString();
            //j = Convert.ToString(i);

            _completed = _correctPassword == writtenPassword;
        }

        public bool IsCorrectPassword(String writtenPassword)
        {
            SetWrittenPassword(writtenPassword);
            return _completed;
        }


        public override void Unlock()
        {
            _physicalPanel.SetActive(true);
        }
    }    
}

