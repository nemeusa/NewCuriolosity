using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRequester : MonoBehaviour
{
    [Header("<color=orange>Clip</color>")]
    [SerializeField] private AudioClip _bMusic;

    private void Start()
    {
        AudioManager.Instance.PlayClip(_bMusic);
    }
}
