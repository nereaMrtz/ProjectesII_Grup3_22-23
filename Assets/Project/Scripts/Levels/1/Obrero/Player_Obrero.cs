using UnityEngine;

namespace Project.Scripts.Levels._1.Obrero
{
    public class Player_Obrero : MonoBehaviour
    {
        private bool _hammer;

        public bool HasHammer()
        {
            return _hammer;
        }

        public void GiveHammer()
        {
            _hammer = true;
        }
    }
}
