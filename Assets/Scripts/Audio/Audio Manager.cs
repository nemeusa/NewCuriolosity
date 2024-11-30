using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    #region Singleton
    public static AudioManager Instance;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        _mSource = GetComponent<AudioSource>();
    }
    #endregion


    #region "Audio Sources"
    [Header("<color=#fce357>Sources</color>")]
    [SerializeField] private AudioMixer _mixer;


    [SerializeField] private AudioSource _impactSource;
    public AudioSource ImpactSource { get { return _impactSource; } private set { } }

    
    [SerializeField] private AudioSource _impactEnemSource;
    public AudioSource ImpactEnemSource { get { return _impactEnemSource; } private set { } }


    [SerializeField] private AudioSource _mbgSource;
    public AudioSource MBGSource { get { return _mbgSource; } private set { } }

    [SerializeField] private AudioSource _fireSource;
    public AudioSource FireSource { get { return _fireSource; } private set { } }


    private AudioSource _mSource;

    #endregion

    private float _masterVol = 0.0f;
    public float MasterVol { get { return _masterVol; } set { _masterVol = value; } }

    private float _musicVol = 0.0f;
    public float MusicVol { get { return _musicVol; } set { _musicVol = value; } }

    private float _sfxVol = 0.0f;
    public float sfxVol { get { return _sfxVol; } set { _sfxVol = value; } }

    [SerializeField] private Scene_Manager _sceneManager;


    #region VolumeSetting
    public void SetMasterVolume(float value)
    {
        _masterVol = value;
        _mixer.SetFloat("Master", Mathf.Log10(value) * 20.0f);
    }

    public void SetMusicVolume(float value)
    {
        _musicVol = value;
        _mixer.SetFloat("Music", Mathf.Log10(value) * 20.0f);
    }

    public void SetSFXVolume(float value)
    {
        _sfxVol = value;
        _mixer.SetFloat("SFX", Mathf.Log10(value) * 20.0f);
    }
    #endregion

    public void PlayClip(AudioClip clip)
    {
        if (_mSource.clip == clip) return;

        _mSource.Stop();

        _mSource.clip = clip;

        _mSource.Play();
    }

    public void DisableMMsfx()
    {
        _mbgSource.Stop();
        _mbgSource.enabled = false;

        _fireSource.Stop();
        _fireSource.enabled = false;

        if(!_mSource.isPlaying) _mSource.Play();
    }

    public void StopMMmusic()
    {
        _sceneManager.GetCurrentScene();
        if (_sceneManager.currentScene == 0)
        {
            _mbgSource.enabled = true;
            _mbgSource.Play();

            _fireSource.enabled = true;
            _fireSource.Play();
        }

        if (_mbgSource.isPlaying || _fireSource.isPlaying)
        {
            _mSource.Stop();
        }
    }
}
