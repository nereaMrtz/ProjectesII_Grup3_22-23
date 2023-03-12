using Project.Scripts.Levels._1._1_1;
using UnityEngine;

namespace Project.Scripts.Levels._1.Descubrelo
{
    public class Button_Descubrelo : Button1_1
    {
        private const int PLAYER_LAYER = 6;
        
        [SerializeField] private GameObject _flowerPotButton;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer != PLAYER_LAYER)
            {
                return;
            }
            ButtonAction();
            _flowerPotButton.SetActive(true);
        }
    }
}
