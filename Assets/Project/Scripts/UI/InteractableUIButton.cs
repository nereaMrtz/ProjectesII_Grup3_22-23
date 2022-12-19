using Project.Scripts.Character;
using UnityEngine;

namespace Project.Scripts.UI
{
    public class InteractableUIButton : MonoBehaviour
    {
        private GameObject _gameObjectAttached;

        private float _distanceToInteract;

        private Player _player;

        public void SetGameObjectAndHisDistanceToInteract(GameObject gameObjectAttached, float distanceToInteract)
        {
            _gameObjectAttached = gameObjectAttached;
            _distanceToInteract = distanceToInteract;
        }

        public void SetPlayer(Player player)
        {
            _player = player;
        }

        public void Interact()
        {
            _player.SetGameObjectAndHisDistanceToInteract(_gameObjectAttached, _distanceToInteract);
        }
    }
}
