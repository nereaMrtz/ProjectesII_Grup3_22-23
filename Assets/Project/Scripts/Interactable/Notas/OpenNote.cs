using Project.Scripts.Managers;
using UnityEngine;

namespace Project.Scripts.Interactable.Notas
{
    public class OpenNote : MonoBehaviour
    {
        //show in inspector, private
        [SerializeField] GameObject Nota;
        [SerializeField] Sprite SobreAbierto;

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

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                Nota.SetActive(true);

                gameObject.GetComponent<SpriteRenderer>().sprite=SobreAbierto;

                //pause game
                Time.timeScale = 0;
                GameManager.Instance.SetPause(true);

                //sonido
                //GetComponent<AudioSource>().Play();
                _audioSource.Play();

            }
        }
    }
}
