using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyController : CreatureController
{
    int lianaLayer = LayerMask.NameToLayer("Lianas");
    public MonkeyController(ChangeAnimal changeAnimal, GameObject mesh, float movSpeed) : base(changeAnimal, mesh, movSpeed)
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
        //int lianaLayer = LayerMask.NameToLayer("Lianas");

        if (other.gameObject.layer == lianaLayer)
        {
            PlayerMovement.lianasActive = true;
            PlayerMovement.enterLianas = true;
            PlayerMovement.lianasGravity = true;
            Debug.Log("enaganchado pa");
        }

        int batLayer = LayerMask.NameToLayer("BatActive");

        if (other.gameObject.layer == batLayer)
        {
            ChangeAnimal.batTrue = true;
            ChangeAnimal.batInto = true;
        }
    }

    public override void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == lianaLayer)
        {
            PlayerMovement.lianasActive = false;
        }
    }

    public override void OnUpdate()
    {
    }

    public override void OnCollisionStay(Collision other)
    {
    }
}
