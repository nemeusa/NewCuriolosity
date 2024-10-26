using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatController : CreatureController
{
    [SerializeField] float raycastMaxDistance = 1f;
    [SerializeField] LayerMask raycastMask;

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
    }

    public override void OnCollisionEnter(Collision collision)
    {
    }

}
