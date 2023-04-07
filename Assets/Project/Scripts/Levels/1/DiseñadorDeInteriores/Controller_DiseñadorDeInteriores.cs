using UnityEngine;

namespace Project.Scripts.Levels._1.DiseñadorDeInteriores
{
    public class Controller_DiseñadorDeInteriores : MonoBehaviour
    {
        [SerializeField] private Button_DiseñadorDeInteriores _button;

        [SerializeField] private Door_DiseñadorDeInteriores _door;

        private Vector3 _teleportButtonPosition;

        private bool _clickedOnButton;
        private bool _clickedOnDoor;

        private int _iterationsBeforeDenyingJustClickedButton = 2;
        private int _iterationsBeforeDenyingJustClickedDoor = 2;
        
        private int _currentIterationsBeforeDenyingJustClickedButton;
        private int _currentIterationsBeforeDenyingJustClickedDoor;

        private void Start()
        {
            _currentIterationsBeforeDenyingJustClickedButton = _iterationsBeforeDenyingJustClickedButton;
            _currentIterationsBeforeDenyingJustClickedDoor = _iterationsBeforeDenyingJustClickedDoor;
            _teleportButtonPosition = new Vector3(_door.GetOffset().x, _door.transform.position.y - _door.GetOffset().y, _door.transform.position.z);
        }

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0))
            {
                return;
            }

            if (_button.IsJustClicked())
            {
                _clickedOnButton = true;
                _currentIterationsBeforeDenyingJustClickedButton = _iterationsBeforeDenyingJustClickedButton;
                _button.DenyClick();
            }

            if (_currentIterationsBeforeDenyingJustClickedButton <= 0)
            {
                _clickedOnButton = false;
            }

            if (_door.IsJustClicked())
            {
                _clickedOnDoor = true;
                _currentIterationsBeforeDenyingJustClickedDoor = _iterationsBeforeDenyingJustClickedDoor;
                _door.DenyClick();
            }

            if (_currentIterationsBeforeDenyingJustClickedDoor <= 0)
            {
                _clickedOnDoor = false;
            }

            if (_clickedOnButton && _clickedOnDoor)
            {
                (_button.transform.position, _door.transform.position) = (_door.transform.position + _teleportButtonPosition,
                    _button.transform.position - _door.GetOffset());
                Destroy(_button);
                Destroy(_door);
                Destroy(this);
            }

            _currentIterationsBeforeDenyingJustClickedButton--;
            _currentIterationsBeforeDenyingJustClickedDoor--;
        }

        public void SetClickedOnButtonTrue()
        {
            _clickedOnButton = true;
        }

        public void SetClickedOnDoorTrue()
        {
            _clickedOnDoor = true;
        }

    }
}
