using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioSource[] _sources;
    [SerializeField] private AudioClip[] _animalClips;
    [SerializeField] private AudioClip[] _damageClips;
    [SerializeField] private AudioClip[] _skillClips;

    private int _currentAnimal = 1;

    public void PlayShootClip()
    {
        _sources[0].Play();
    }

    public void PlayTransClip()
    {
        _sources[1].Play();
    }

    public void PlayAnimalClip(int animal)
    {
        _currentAnimal = animal;

        if (animal == 1)
        {
            _sources[2].clip = _animalClips[0];
            _sources[2].Play();
        }

        if (animal == 2)
        {
            _sources[2].clip = _animalClips[1];
            _sources[2].Play();
        }

        if (animal == 3)
        {
            _sources[2].clip = _animalClips[2];
            _sources[2].Play();
        }

        if (animal == 4)
        {
            _sources[2].clip = _animalClips[3];
            _sources[2].Play();
        }

        if(animal == 5)
        {
            PickMonkeyCLip();
            _sources[2].Play();
        }

        if (animal == 6)
        {
            _sources[2].clip = _animalClips[6];
            _sources[2].Play();
        }
    }

    public void PlayLifeClip(float life)
    {
        if (life > 0f)
        {
            _sources[3].clip = _damageClips[0];
            _sources[3].Play();
        }

        if (life <= 0f)
        {
            _sources[3].clip = _damageClips[1];
            _sources[3].Play();
        }
    }

    public void PlaySkillClip()
    {
        if (_currentAnimal == 3) _sources[4].clip = _skillClips[0];

        if (_currentAnimal == 4) _sources[4].clip = _skillClips[1];

        _sources[4].Play();
    }

    public void PickMonkeyCLip()
    {
        var chance = Random.Range(0, 11);
        if (chance > 2)
        {
            _sources[2].clip = _animalClips[4];
        }
        else
        {
            _sources[2].clip = _animalClips[5];
        }
    }
}
