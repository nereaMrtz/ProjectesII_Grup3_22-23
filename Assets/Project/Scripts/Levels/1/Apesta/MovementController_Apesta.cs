using Project.Scripts.Character;
using UnityEngine;

namespace Project.Scritps.Levels.Apesta
{
    public class MovementController_Apesta : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private float _distance = 4;

        private void Update()
        {
            if (Input.GetMouseButton(0)) 
            {
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
                _player.SetMovementDirection(new Vector3(0, 0, 0));
            }
        }
    }
}