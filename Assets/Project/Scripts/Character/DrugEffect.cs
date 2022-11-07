using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Character
{
    public class DrugEffect : MonoBehaviour
    {
        private bool _canChangeState = true;

        public void ChangeState()
        {
            if (_canChangeState)
            {
                GameManager.Instance.SetDrugged(!GameManager.Instance.IsDrugged());    
            }
        }

        public void SetCanChangeState(bool canChangeState)
        {
            _canChangeState = canChangeState;
        }

        public bool GetCanChangeState()
        {
            return _canChangeState;
        }
    }
}