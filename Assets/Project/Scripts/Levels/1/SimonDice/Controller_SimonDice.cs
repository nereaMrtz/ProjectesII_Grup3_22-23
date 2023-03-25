using System.Collections;
using UnityEngine;

namespace Project.Scripts.Levels._1.SimonDice
{
    public class Controller_SimonDice : MonoBehaviour
    {
        private const int COMBINATION_LENGTH = 8;

        [SerializeField] private StartGameButton_SimonDice _startGameButton;
        
        [SerializeField] private UnclickableButton_SimonDice[] _unclickableButtons;
        [SerializeField] private ClickableButton_SimonDice[] _clickableButtons;

        [SerializeField] private GameObject[] _buttonsParent;

        [SerializeField] private SpriteRenderer[] _unclickableButtonsSpriteRenderer;
        [SerializeField] private SpriteRenderer[] _clickableButtonsSpriteRenderer;

        private string _correctCombination;
        private string _currentCombination;

        private int _maxCombinationLenght = 9;
        private int _currentCombinationLength = 3;

        public void StartGame()
        {
            for (int i = 0; i < _buttonsParent.Length; i++)
            {
                _buttonsParent[i].SetActive(true);
            }

            for (int i = 0; i < _unclickableButtons.Length; i++)
            {
                StartCoroutine(FadeInButton(_unclickableButtonsSpriteRenderer[i]));
            }

            for (int i = 0; i < _clickableButtons.Length; i++)
            {
                StartCoroutine(FadeInButton(_clickableButtonsSpriteRenderer[i]));
            }
            
            CreateCombination();
            
        }

        private void Endgame()
        {

            for (int i = 0; i < _unclickableButtons.Length; i++)
            {
                StartCoroutine(FadeOutButton(_unclickableButtonsSpriteRenderer[i], _buttonsParent[0]));
            }

            for (int i = 0; i < _clickableButtons.Length; i++)
            {
                StartCoroutine(FadeOutButton(_clickableButtonsSpriteRenderer[i], _buttonsParent[1]));
            }
            
            for (int i = 0; i < _buttonsParent.Length; i++)
            {
                _buttonsParent[i].SetActive(false);
            }
            
            _startGameButton.gameObject.SetActive(true);
        }

        public void CheckCombination(int buttonIndex)
        {
            _currentCombination += buttonIndex.ToString();
            
            for (int i = 0; i < _currentCombination.Length; i++)
            {
                if (_currentCombination[i] != _correctCombination[i])
                {
                    Endgame();
                }
            }
        }

        private void CreateCombination()
        {
            for (int i = 0; i < _maxCombinationLenght; i++)
            {
                _correctCombination += Random.Range(0, _unclickableButtons.Length).ToString();
            }
        }
        
        private IEnumerator FadeOutButton(SpriteRenderer spriteRenderer, GameObject buttonParent)
        {
            Color color = spriteRenderer.color;
            
            float auxAlpha = color.a;
            
            while (auxAlpha > 0f)
            {
                auxAlpha -= Time.deltaTime;
                spriteRenderer.color = new Color(color.r, color.g, color.b, auxAlpha);
                yield return null;
            }
            buttonParent.SetActive(false);
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
    }
}
