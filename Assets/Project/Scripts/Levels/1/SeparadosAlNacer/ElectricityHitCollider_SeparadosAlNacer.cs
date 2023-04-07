using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.Levels._1.SeparadosAlNacer
{
    public class ElectricityHitCollider_SeparadosAlNacer : MonoBehaviour
    {
        [SerializeField] private ElectricityPanel_SeparadosAlNacer _electricityPanel;

        private float _timeToConnect = 1;

        private void OnMouseEnter()
        {
            Debug.Log("Holi");
            
            if (Time.time - _electricityPanel.GetTime() > _timeToConnect)
            {
                return;
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
