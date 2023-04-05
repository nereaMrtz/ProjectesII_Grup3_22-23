using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.UI
{
    public class ResetLevelButton : MonoBehaviour
    {
        private const String TINT_AMOUNT = "_TintAmount";
        
        [SerializeField] private Material _blinkMaterial;

        [SerializeField] private float _blinkSpeed;

        private float _tintAmount;

        private bool _flash;
        
        private bool _blink;

        private void Start()
        {
            _blinkMaterial.SetFloat(TINT_AMOUNT, 0);
        }

        public void ResetLvl()
        {
            _blink = false;
            _blinkMaterial.SetFloat(TINT_AMOUNT, 0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public IEnumerator FlashButton()
        {
            _blink = true;
            
            while (_blink)
            {

                if (_flash)
                {
                    _tintAmount += Time.deltaTime * _blinkSpeed;
                    if (_tintAmount >= 1.0f)
                    {
                        _flash = false;
                    }
                }
                else
                {
                    _tintAmount -= Time.deltaTime * _blinkSpeed;
                    if (_tintAmount <= 0.0f)
                    {
                        _flash = true;
                    }
                }
                
                _blinkMaterial.SetFloat("_TintAmount", _tintAmount);
                yield return null;
            }
        }
    }
}
