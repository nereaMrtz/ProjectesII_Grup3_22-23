using UnityEngine;

namespace Project.Scripts.Levels._1.DiseñadorDeInteriores
{
    public class Button_DiseñadorDeInteriores : MonoBehaviour
    {
        [SerializeField] private Door_DiseñadorDeInteriores _door;

        private bool _clicked;

        private void OnMouseDown()
        {
            if (_door.GetClicked())
            {
                (transform.position, _door.transform.position) = (_door.GetTeleportButtonPosition(), transform.position - _door.GetOffset());    
                Destroy(this);
            }

            _clicked = true;
        }

        public bool GetClicked()
        {
            return _clicked;
        }
    }
}