using System;
using Project.Scripts.Interactable.Static;
using Project.Scripts.Levels._1._1_1;
using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Levels._1.LaVistaEngaña
{
    public class Door_LaVistaEngaña : Door
    {
        public override void Unlock()
        {
            AudioManager.Instance.Play(SIMPLE_DOOR_SOUND);
            _unlocked = true;
            ChangePolygonCollider(1);
        }
    }
}
