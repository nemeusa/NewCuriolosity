using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderAction : MonoBehaviour
{
    [Header("<color=orange>Audio</color>")]
    [Range(0.0001f, 1.0f)][SerializeField] private float _masterVolume = 1.0f;
    [Range(0.0001f, 1.0f)][SerializeField] private float _musicVolume = 0.1f;
    [Range(0.0001f, 1.0f)][SerializeField] private float _sfxVolume = 1.0f;

    [Header("<color=yellow>Sliders</color>")]
    [SerializeField] private Slider _masterSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;

    private void Start()
    {
        if(AudioManager.Instance.MasterVol != 0.0f)
        {
            _masterSlider.value = AudioManager.Instance.MasterVol;
        }
        else
        {
            _masterSlider.value = _masterVolume;
            AudioManager.Instance.SetMasterVolume(_masterVolume);
        }

        if (AudioManager.Instance.MusicVol != 0.0f)
        {
            _musicSlider.value = AudioManager.Instance.MusicVol;
        }
        else
        {
            _musicSlider.value = _musicVolume;
            AudioManager.Instance.SetMusicVolume(_musicVolume);
        }

        if (AudioManager.Instance.sfxVol != 0.0f)
        {
            _sfxSlider.value = AudioManager.Instance.sfxVol;
        }
        else
        {
            _sfxSlider.value = _sfxVolume;
            AudioManager.Instance.SetSFXVolume(_sfxVolume);
        }
    }

    public void SetMasterVolume(float value)
    {
        AudioManager.Instance.SetMasterVolume(value);
    }

    public void SetMusicVolume(float value)
    {
        AudioManager.Instance.SetMusicVolume(value);
    }

    public void SetSfxVolume(float value)
    {
        AudioManager.Instance.SetSFXVolume(value);
    }
}
