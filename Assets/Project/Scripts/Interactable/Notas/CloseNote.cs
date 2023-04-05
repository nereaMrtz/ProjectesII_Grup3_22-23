using Project.Scripts.Managers;
using UnityEngine;

public class CloseNote : MonoBehaviour
{

    private AudioSource _audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.SetAudioSourceComponent(_audioSource, "hoja");
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
