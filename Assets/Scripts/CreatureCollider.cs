using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreatureCollider : MonoBehaviour
{
    [SerializeField] ChangeAnimal _changeAnimal;

    private void OnCollisionEnter(Collision other)
    {
        _changeAnimal.currentCreature.OnCollisionEnter(other);
    }

    public void OnCollisionStay(Collision other)
    {
        _changeAnimal.currentCreature.OnCollisionStay(other);
    }
}
