using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : CreatureController
{
    public AlienController(ChangeAnimal changeAnimal, GameObject mesh, float movSpeed) : base(changeAnimal, mesh, movSpeed)
    {
    }

    public override void OnCollisionEnter(Collision collision)
    {
    }

    public override void OnFixedUpdate()
    {
    }

    public override void OnStart()
    {
    }

    public override void OnTriggerEnter(Collider other)
    {
    }

    public override void OnUpdate()
    {
    }
}
