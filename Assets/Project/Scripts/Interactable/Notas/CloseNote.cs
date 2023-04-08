using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Interactable.Notas
{
    public class CloseNote : MonoBehaviour
    {

        private AudioSource _audioSource;
    
        // Start is called before the first frame update
        void Start()
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
            AudioManager.Instance.SetAudioSourceComponent(_audioSource, "Sheet Of Paper Sound");
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        public void Close()
        {
            gameObject.transform.parent.gameObject.SetActive(false);

            //desactivar pausa
            Time.timeScale = 1;
            GameManager.Instance.SetPause(false);

            //sonido
            //GetComponent<AudioSource>().Play();
            _audioSource.Play();
        }
    }
}
