using Project.Scripts.Levels._1._1_1;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1.Tinder
{
    public class Table_Tinder : MonoBehaviour
    {
        private const int PLAYER_LAYER = 6;

        [SerializeField] private GameObject _mobileCanvas;

        [SerializeField] private Door _door;
        
        private void OnCollisionEnter2D(Collision2D collision2D)
        {
            if (_door.IsUnlocked())
            {
                return;
            }
            
            if (collision2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            
            GameManager.Instance.SetPause(true);
            _mobileCanvas.SetActive(true);
        }
    }
}
