using Project.Scripts.Character;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scritps.Levels.Apesta
{
    public class MovementController_Apesta : MonoBehaviour
    {
        [SerializeField] private Player _player;

        [SerializeField] private GameObject _smellParticle;

        private float _distance = 2;

        private void Update()
        {
            if (GameManager.Instance.IsPause())
            {
                return;
            }

            if (Input.GetMouseButton(0)) 
            {
                _smellParticle.SetActive(true);
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;
                if ((_player.transform.position - mousePosition).magnitude <= _distance)
                {
                    _player.SetMovementDirection(_player.transform.position - mousePosition);                    
                }
                else
                {
                    _player.SetMovementDirection(new Vector3(0, 0, 0));
                }
            }
            else
            {
                _smellParticle.SetActive(false);
                _player.SetMovementDirection(new Vector3(0, 0, 0));
            }
        }
    }
}