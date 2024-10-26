using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CreatureController 
{
    protected float _movSpeed;
    protected GameObject _mesh;

    protected ChangeAnimal _changeAnimal;

    public CreatureController(ChangeAnimal changeAnimal, GameObject mesh, float movSpeed)
    {
        _changeAnimal = changeAnimal;
        _mesh = mesh;
        _movSpeed = movSpeed;
    }

    public virtual void OnChange()
    {
        _changeAnimal.playerMovement.ChangeSpeed(_movSpeed);

        _mesh.SetActive(true);
    }

    public virtual void OnDisable()
    {
        _mesh.SetActive(false);
    }

    public abstract void OnStart();

    public abstract void OnUpdate();

    public abstract void OnFixedUpdate();

    public virtual bool CanChange()
    {
        return true;
    }
    public abstract void OnTriggerEnter(Collider other);

    public abstract void OnCollisionEnter(Collision collision);
}
