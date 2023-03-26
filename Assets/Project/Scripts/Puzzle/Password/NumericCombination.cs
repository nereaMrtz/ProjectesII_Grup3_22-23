using Project.Scripts.Managers;
using TMPro;
using UnityEngine;

namespace Project.Scripts.Puzzle.Password
{
    public class NumericCombination : PuzzleScript
    {
        [SerializeField] private GameObject _zoomInPanel;
        
        [SerializeField] private TMP_Text[] _texts;
        
        [SerializeField] private int[] _correctAnswers;
        [SerializeField] private int _minimumNumber;
        [SerializeField] private int _maximumNumber;

        private Color _initialColor = new Color(0.38f, 0.38f, 0.38f, 0.63f);
        private Color _blinkColor = Color.black;
        private Color _activeColor;
        
        private int _correctAnswersWrote;
        private int _activeText;

        private float _blinkTime = 1;
        private float _currentTimeToBlink;

        private bool _iterated;

        private void Start()
        {
            _currentTimeToBlink = 0;
            
            for (int i = 0; i < _texts.Length; i++)
            {
                _texts[i].text = "0";
                _texts[i].color = _initialColor;
            }
        }

        private void Update()
        {
            CheckAnswers();
            
            IterateBetweenFields();
            
            IterateBetweenNumbers();
            
            SelectedText();
        }

        private void CheckAnswers()
        {
            _correctAnswersWrote = 0;
            
            for (int i = 0; i < _texts.Length; i++)
            {
                if (_texts[i].text == _correctAnswers[i].ToString())
                {
                    _correctAnswersWrote++;
                }
            }
            
            _completed = _correctAnswersWrote == _correctAnswers.Length;
            if (_completed)
            {
                _zoomInPanel.SetActive(false);
                GameManager.Instance.SetZoomInState(false);
            }
        }

        private void IterateBetweenNumbers()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                int number = int.Parse(_texts[_activeText].text);
                number++;
                if (number > _maximumNumber)
                {
                    number = _minimumNumber;
                }
                _texts[_activeText].text = number.ToString();
                _currentTimeToBlink = 1;
                _iterated = true;
                _activeColor = _blinkColor;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                int number = int.Parse(_texts[_activeText].text);
                number--;
                if (number < _minimumNumber)
                {
                    number = _maximumNumber;
                }
                _texts[_activeText].text = number.ToString();
                _currentTimeToBlink = 1;
                _iterated = true;
                _activeColor = _blinkColor;
            }
        }

        private void IterateBetweenFields()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _currentTimeToBlink = 1;
                _texts[_activeText].color = new Color(0.38f, 0.38f, 0.38f, 0.63f);
                _activeText++;
                if (_activeText > _texts.Length - 1)
                {
                    _activeText = 0;
                }

                _iterated = true;
                _activeColor = _blinkColor;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _currentTimeToBlink = 1;
                _texts[_activeText].color = _initialColor;
                _activeText--;
                if (_activeText < 0)
                {
                    _activeText = _texts.Length - 1;
                }
                
                _iterated = true;
                _activeColor = _blinkColor;
            }
        }

        private void SelectedText()
        {
            if (_currentTimeToBlink > 0)
            {
                _currentTimeToBlink -= Time.deltaTime;
            }
            else
            {
                _activeColor = _iterated ? _initialColor : _blinkColor;
                _iterated = !_iterated;
                _currentTimeToBlink = _blinkTime;
            }
            
            _texts[_activeText].color = _activeColor;
        }
    }
}
