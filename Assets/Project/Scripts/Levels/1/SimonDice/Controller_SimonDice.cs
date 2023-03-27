using System.Collections;
using Project.Scripts.Levels._1._1_1;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Project.Scripts.Levels._1.SimonDice
{
    public class Controller_SimonDice : MonoBehaviour
    {
        private const int ADD_INDEX = 3;

        private const float TIME_TO_START_SHOWING_COMBINATION = 0.65f;
        
        [SerializeField] private Door _door;
        
        [SerializeField] private StartGameButton_SimonDice _startGameButton;
        
        [SerializeField] private UnclickableButton_SimonDice[] _unclickableButtons;
        [SerializeField] private ClickableButton_SimonDice[] _clickableButtons;

        [SerializeField] private GameObject[] _buttonsParent;

        [SerializeField] private SpriteRenderer[] _spriteRendererUnclickableButtons;
        [SerializeField] private SpriteRenderer[] _spriteRendererClickableButtons;

        [SerializeField] private CapsuleCollider2D[] _capsuleCollider2DClickableButtons;

        [SerializeField] private string _correctCombination;
        [SerializeField] private string _currentCombination;

        private int _currentIndex;
        
        private int _maxCombinationLength = ADD_INDEX * 3;
        private int _currentCombinationLength = ADD_INDEX;

        public void StartGame()
        {
            for (int i = 0; i < _buttonsParent.Length; i++)
            {
                _buttonsParent[i].SetActive(true);
            }

            for (int i = 0; i < _unclickableButtons.Length; i++)
            {
                StartCoroutine(FadeInButton(_spriteRendererUnclickableButtons[i]));
            }

            for (int i = 0; i < _clickableButtons.Length; i++)
            {
                StartCoroutine(FadeInButton(_spriteRendererClickableButtons[i]));
            }
            
            CreateCombination();
        }

        private void CreateCombination()
        {
            for (int i = 0; i < ADD_INDEX; i++)
            {
                _correctCombination += Random.Range(0, _unclickableButtons.Length).ToString();
            }

            StartCoroutine(ShowCombination());
        }

        private void AddCombination()
        {
            for (int i = 0; i < _unclickableButtons.Length; i++)
            {
                StartCoroutine(TurnOnButton(_spriteRendererUnclickableButtons[i]));
            }

            for (int i = 0; i < _clickableButtons.Length; i++)
            {
                StartCoroutine(TurnOffButton(_spriteRendererClickableButtons[i]));
            }
            
            _currentCombinationLength += ADD_INDEX;
            CreateCombination();
        }

        public void CheckCombination(int buttonIndex)
        {
            if (_door.IsUnlocked())
            {
                return;
            }
            _currentCombination += buttonIndex.ToString();
            
            if (_currentCombination[_currentIndex] != _correctCombination[_currentIndex])
            {
                Endgame();
            }
            else
            {
                _currentIndex++;
                
                if (_currentIndex == _maxCombinationLength)
                {
                    _door.Unlock(0.1f);
                }
                else if (_currentIndex == _currentCombinationLength)
                {
                    _currentIndex = 0;
                    _currentCombination = "";
                    AddCombination();
                }
            }
        }

        private void Endgame()
        {
            _currentIndex = 0;
            _correctCombination = "";
            _currentCombination = "";
            
            for (int i = 0; i < _unclickableButtons.Length; i++)
            {
                StartCoroutine(FadeOutButton(_spriteRendererUnclickableButtons[i], 0));
            }

            for (int i = 0; i < _clickableButtons.Length; i++)
            {
                StartCoroutine(FadeOutButton(_spriteRendererClickableButtons[i], 1));
            }

            for (int i = 0; i < _capsuleCollider2DClickableButtons.Length; i++)
            {
                _capsuleCollider2DClickableButtons[i].enabled = false;
            }
            
            _startGameButton.gameObject.SetActive(true);
        }

        private IEnumerator ShowCombination()
        {
            int auxCurrentCombinationLength = _currentCombinationLength;
            int indexCounter = 0;
            float timeToChange;

            for (int i = 0; i < _capsuleCollider2DClickableButtons.Length; i++)
            {
                _capsuleCollider2DClickableButtons[i].enabled = false;
            }

            yield return new WaitForSeconds(TIME_TO_START_SHOWING_COMBINATION);

            while (auxCurrentCombinationLength > 0)
            {
                timeToChange = 1f;
                
                while (timeToChange >= 0.5f)
                {
                    timeToChange -= Time.deltaTime;  

                    yield return null;
                }
                
                _unclickableButtons[(int)char.GetNumericValue(_correctCombination[indexCounter])].PressButton();

                while (timeToChange > 0f)
                {
                    timeToChange -= Time.deltaTime;  

                    yield return null;
                }
                
                _unclickableButtons[(int)char.GetNumericValue(_correctCombination[indexCounter])].PressButton();
                
                indexCounter++;
                auxCurrentCombinationLength--;
            }

            for (int i = 0; i < _unclickableButtons.Length; i++)
            {
                StartCoroutine(TurnOffButton(_spriteRendererUnclickableButtons[i]));
            }

            for (int i = 0; i < _clickableButtons.Length; i++)
            {
                StartCoroutine(TurnOnButton(_spriteRendererClickableButtons[i]));
            }

            yield return new WaitForSeconds(TIME_TO_START_SHOWING_COMBINATION);
            
            for (int i = 0; i < _capsuleCollider2DClickableButtons.Length; i++)
            {
                _capsuleCollider2DClickableButtons[i].enabled = true;
            }
        }

        private IEnumerator FadeOutButton(SpriteRenderer spriteRenderer, int buttonParentIndex)
        {
            Color color = spriteRenderer.color;
            
            float auxAlpha = color.a;
            
            while (auxAlpha > 0f)
            {
                auxAlpha -= Time.deltaTime;
                spriteRenderer.color = new Color(color.r, color.g, color.b, auxAlpha);
                yield return null;
            }

            if (buttonParentIndex == 0)
            {
                StartCoroutine(TurnOnButton(spriteRenderer));
            }
            else
            {
                StartCoroutine(TurnOffButton(spriteRenderer));
            }
            
            _buttonsParent[buttonParentIndex].SetActive(false);
        }
        
        private IEnumerator FadeInButton(SpriteRenderer spriteRenderer)
        {
            Color color = spriteRenderer.color;
            
            float auxAlpha = color.a;
            
            while (auxAlpha < 1f)
            {
                auxAlpha += Time.deltaTime;
                spriteRenderer.color = new Color(color.r, color.g, color.b, auxAlpha);
                yield return null;
            }
        }
        
        private IEnumerator TurnOffButton(SpriteRenderer spriteRenderer)
        {
            float auxColor = 1;
            float alpha = spriteRenderer.color.a;
            
            while (auxColor > 0.5f)
            {
                auxColor -= Time.deltaTime;
                spriteRenderer.color = new Color(auxColor, auxColor, auxColor, alpha);
                yield return null;
            }
        }

        private IEnumerator TurnOnButton(SpriteRenderer spriteRenderer)
        {
            float auxColor = 0.5f;
            float alpha = spriteRenderer.color.a;

            while (auxColor < 1f)
            {
                auxColor += Time.deltaTime;
                spriteRenderer.color = new Color(auxColor, auxColor, auxColor, alpha);
                yield return null;
            }
        }
    }
}
