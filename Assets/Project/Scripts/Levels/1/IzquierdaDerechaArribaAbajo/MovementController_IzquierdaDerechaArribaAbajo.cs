using System.Collections;
using Project.Scripts.Character;
using Project.Scripts.NoMonoBehaviourClass;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.Scripts.Levels._1.IzquierdaDerechaArribaAbajo
{
    public class MovementController_IzquierdaDerechaArribaAbajo : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        [SerializeField] private Direction[] _directions;

        [SerializeField] private Player _player;

        private Vector2 _movementDirection;

        private bool _pressed;

        public void OnPointerDown(PointerEventData eventData)
        {
            _player.SetMoving(true);
            _pressed = true;
            _movementDirection = _directions[0].GetVector();
            StartCoroutine(PlayerMovement());
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _player.SetMoving(false);
            _pressed = false;
        }

        private IEnumerator PlayerMovement()
        {
            while (_pressed)
            {
                
                _player.SetMovement(_movementDirection);
                _player.SetMovementDirection(_movementDirection);
                yield return null;
            }
            _movementDirection = Vector2.zero;
            _player.SetMovementDirection(_movementDirection);
        }
    }
}
