using System;
using UnityEngine;

namespace Project.Scripts.CanvasScripts
{
    public class AttachToAnObject : MonoBehaviour
    {
        [SerializeField] private GameObject _gameObjectToAttach; 
        [SerializeField] private Vector2 _offSet;
        private void Update() 
        { 
            Attach(); 
        }
         
        private void Attach()
        {
            Vector2 _transformGameObject = new Vector2(_gameObjectToAttach.transform.position.x + _offSet.x, _gameObjectToAttach.transform.position.y + _offSet.y);
            
            gameObject.transform.position = _transformGameObject;
        }
    }
}
