using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSoundEvent : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        _audioSource.Play();
    }
}
