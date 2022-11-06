using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Level
{
    public class DrugSubjectElement : MonoBehaviour
    {
        [SerializeField] private bool _canChange;

        public bool GetCanChange()
        {
            return _canChange;
        }

        public void SetCanChange(bool canChange)
        {
            _canChange = canChange;
        }
    } 
}

