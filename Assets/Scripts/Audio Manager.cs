using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
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

    [Header("<color=#fce357>Clips</color>")]
    public AudioClip background;
    public AudioClip transformation;
    public AudioClip rat;
    public AudioClip goat;
    public AudioClip turtle;
    public AudioClip bullet;


    private void Start()
    {
        _mSource.clip = background;
        _mSource.Play();

        _tSource.clip = transformation;

        _ratSource.clip = rat;
        _goatSource.clip = goat;
        _turtleSource.clip = turtle;
        _bulletSource.clip = bullet;
    }
}
