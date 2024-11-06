using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRequester_Menu : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.MBGSource.Play();
        AudioManager.Instance.FireSource.Play();
    }
}
