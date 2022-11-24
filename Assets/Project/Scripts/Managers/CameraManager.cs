using Project.Scripts.Camera;
using Project.Scripts.Interactable.Static;
using UnityEngine;

namespace Project.Scripts.Managers
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private PolygonCollider2D[] _cameraConfiners;

        [SerializeField] private CameraBoundingShapeTrigger[] _cameraBoundingShapeTriggers;

        [SerializeField] private CameraBoundingShapeTrigger[] _modifiableCameraBoundingShapeTriggers;
        
                
        
    }   
}