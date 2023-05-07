using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.UI
{
    public class ResetProgress : MonoBehaviour
    {
        public void ResetLevels()
        {
            GameManager.Instance.ResetLevels();
        }
    }
}
