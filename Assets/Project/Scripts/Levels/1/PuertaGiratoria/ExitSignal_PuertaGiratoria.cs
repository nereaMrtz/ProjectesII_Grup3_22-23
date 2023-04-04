using System;
using Project.Scripts.Levels._1._1_1;
using Project.Scripts.ZoomInForPuzzles.DraggableObject.Rotable;
using UnityEngine;

namespace Project.Scripts.Levels._1.PuertaGiratoria
{
    public class ExitSignal_PuertaGiratoria : RotableObject
    {
        [SerializeField] private Door _door;
        
        private void Update()
        {
            if (Math.Abs(transform.localEulerAngles.z) <= 1f )
            {
                transform.localRotation = new Quaternion();
                _door.Unlock();
                Destroy(this);
            }
        }
    }
}
