using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.UI
{
    public class HintButton : MonoBehaviour
    {
 
        public void StopPlayerMovement()
        {
            GameManager.Instance.SetZoomInState(true);
        }

        public void ActivePlayerMovement()
        {
            GameManager.Instance.SetZoomInState(false);

        }
    }
}
