using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager_Menu : MonoBehaviour
{
    [SerializeField] private AudioSource _mSource;
    [SerializeField] private AudioSource _fSource;

    public AudioClip background;
    public AudioClip fire;

    private void Start()
    {
        _mSource.clip = background;
        _mSource.Play();

        _fSource.clip = fire;
        _fSource.Play();
    }
}
