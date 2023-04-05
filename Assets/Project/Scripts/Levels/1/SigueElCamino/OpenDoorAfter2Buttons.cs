using System;
using Project.Scripts.Managers;
using UnityEngine;

public class OpenDoorAfter2Buttons : MonoBehaviour
{
    private const String PRESS_BUTTON = "Press Button";
    private const String RELEASE_BUTTON = "Release Button";
    
    [SerializeField] protected Animator _animator;

    [SerializeField] protected GameObject _button2;

    private AudioSource _audioSourcePressButton;
    private AudioSource _audioSourceReleaseButton;

    private bool _pressed;

    private void Start()
    {
        _audioSourcePressButton = gameObject.AddComponent<AudioSource>();
        _audioSourceReleaseButton = gameObject.AddComponent<AudioSource>();
        AudioManager.Instance.SetAudioSourceComponent(_audioSourcePressButton, PRESS_BUTTON);
        AudioManager.Instance.SetAudioSourceComponent(_audioSourceReleaseButton, RELEASE_BUTTON);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            _audioSourcePressButton.Play();
            _animator.SetTrigger("Press");
            _button2.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.layer == 6)
        {
            _audioSourceReleaseButton.Play();
            _animator.SetTrigger("Press");
        }
    }
}