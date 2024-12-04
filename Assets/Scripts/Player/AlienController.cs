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
        int batLayer = LayerMask.NameToLayer("BatActive");

        if (other.gameObject.layer == batLayer)
        {
            ChangeAnimal.batTrue = true;
            ChangeAnimal.batInto = true;
        }
    }
    public override void OnTriggerExit(Collider other)
    {
    }

    public override void OnUpdate()
    {
    }

    public override void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            PlayerMovement.takeWall = true;
        }

        else PlayerMovement.takeWall = false;

    }
}
