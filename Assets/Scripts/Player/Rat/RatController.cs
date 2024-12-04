using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatController : CreatureController
{
    [SerializeField] float raycastMaxDistance = 2f;
    [SerializeField] LayerMask raycastMask;
    int climpLayer = LayerMask.NameToLayer("Climp");
    //lic static bool dontChanges;

    public RatController(ChangeAnimal changeAnimal, GameObject mesh, float movSpeed) : base(changeAnimal, mesh, movSpeed)
    {
    }

    public override void OnFixedUpdate()
    {
    }

    public override void OnStart()
    {
        throw new System.NotImplementedException();
    }

    public override void OnUpdate()
    {
    }

    public override bool CanChange()
    {
        return !Physics.Raycast(_mesh.transform.position, _mesh.transform.up, raycastMaxDistance, _changeAnimal.layerMask);
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == climpLayer && !PlayerMovement.climpSquirrel)
        {
            PlayerMovement.climpSquirrel = true;
            PlayerMovement.enterLianas = true;
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
        if (other.gameObject.layer == climpLayer)
        {
            Debug.Log("sali :D");
            PlayerMovement.climpSquirrel = false;
        }
    }

    public override void OnCollisionEnter(Collision collision)
    {

    }
    public override void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            PlayerMovement.takeWall = true;
            //ntChanges = true;
        }

        else PlayerMovement.takeWall = false;

    }
}
