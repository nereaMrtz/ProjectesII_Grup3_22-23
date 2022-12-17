using System;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Interactable.Static.NotRequiredInventory
{
    public class SafeBox : NotRequiredInventoryInteractable
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        [SerializeField] private Sprite _openBoxSprite;
        
        [SerializeField] private GameObject _reward;

        private void Start()
        {
            _reward.transform.position = transform.position;
            _reward.SetActive(true);
        }

        public override void Interact(AudioManager audioManager)
        {
            //_reward.SetActive(true);
            //ACTIVAR ZOOM IN
            //CUANDO HA ESCRITO LA COMBINACION CORRECTA CERRAR EL CANVAS
        }

        public void Open()
        {
            _reward.SetActive(true);
            _spriteRenderer.sprite = _openBoxSprite;
        }

    }
}
