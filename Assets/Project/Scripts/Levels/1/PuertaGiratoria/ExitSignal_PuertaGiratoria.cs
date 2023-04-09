using Project.Scripts.Levels._1._1_1;
using Project.Scripts.ZoomInForPuzzles.DraggableObject.Rotable;
using UnityEngine;

namespace Project.Scripts.Levels._1.PuertaGiratoria
{
    public class ExitSignal_PuertaGiratoria : RotableObject
    {
        [SerializeField] private Door _door;

        private float _lastZRotation;

        private void Update()
        {
            if ((_lastZRotation >= 300 && transform.localEulerAngles.z <= 60) || (_lastZRotation <= 60 && transform.localEulerAngles.z >= 300))
            {
                
                transform.localRotation = new Quaternion();
                _door.Unlock();
                Destroy(this);
            }
            _lastZRotation = transform.localEulerAngles.z;
        }
    }
}
