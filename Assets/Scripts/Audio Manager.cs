using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region "Audio Sources"

    [Header("<color=#fce357>Sources</color>")]
    [SerializeField] private AudioSource _mSource;
    [SerializeField]  private AudioSource _tSource;
    public AudioSource tSource
    {
        get { return _tSource; } set { _tSource = value; }
    }

    [SerializeField] private AudioSource _ratSource;
    public AudioSource RatSource
    {
        get { return _ratSource; }
        set { _ratSource = value; }
    }

    [SerializeField] private AudioSource _goatSource;
    public AudioSource GoatSource
    {
        get { return _goatSource; }
        set { _goatSource = value; }
    }

    [SerializeField] private AudioSource _turtleSource;
    public AudioSource TurtleSource
    {
        get { return _turtleSource; }
        set { _turtleSource = value; }
    }

    [SerializeField] private AudioSource _bulletSource;
    public AudioSource BulletSource
    {
        get { return _bulletSource; }
        set { _bulletSource = value; }
    }

    [SerializeField] private AudioSource _damageSource;
    public AudioSource DamageSource
    {
        get { return _damageSource; }
        set { _damageSource = value; }
    }

    [SerializeField] private AudioSource _deathSource;
    public AudioSource DeathSource
    {
        get { return _deathSource; }
        set { _deathSource = value; }
    }

    [SerializeField] private AudioSource _shieldSource;
    public AudioSource ShieldSource
    {
        get { return _shieldSource; }
        set { _shieldSource = value; }
    }

    #endregion

    #region "Audio Clips"

    [Header("<color=#fce357>Clips</color>")]
    public AudioClip background;
    public AudioClip transformation;
    public AudioClip rat;
    public AudioClip goat;
    public AudioClip turtle;
    public AudioClip bullet;
    public AudioClip damage;
    public AudioClip death;
    public AudioClip shield;

    #endregion


    private void Start()
    {
        _mSource.clip = background;
        _mSource.Play();

        _tSource.clip = transformation;

        _ratSource.clip = rat;
        _goatSource.clip = goat;
        _turtleSource.clip = turtle;
        _bulletSource.clip = bullet;
        _damageSource.clip = damage;
        _deathSource.clip = death;
        _shieldSource.clip = shield;
    }
}
