using System;
using Project.Scripts.Puzzle.Password;
using UnityEngine;
using Project.Scripts.FeedbackCircle;
using Project.Scripts.Managers;
using TMPro;
using UnityEngine.UI;

namespace Project.Scripts.Puzzle.MathsPuzzle {
    public class FirstPuzzle : PasswordPuzzle
    {
        [SerializeField] private BoxCollider2D disableCollider;
        [SerializeField] private GameObject endPuzzle;
        [SerializeField] private Circle circle;
        [SerializeField] private TMP_InputField inputField;

        public void CheckAnswer(string answer)
        {
            if (answer == _correctPassword)
            {
                _completed = true;
                disableCollider.enabled = false;
                circle.EndCircle();
                endPuzzle.SetActive(false);
                
                GameManager.Instance.SetZoomInState(false);
            }
        }

        public void Update()
        {
            if (Input.GetKey(KeyCode.Return))
            {
                CheckAnswer(inputField.text);
                inputField.text = "";
            }
        }
    }
}