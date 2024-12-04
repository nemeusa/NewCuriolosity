using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatController : CreatureController
{
    [SerializeField] float _velocityForDestruction = 12f;
   // [SerializeField] private float maxSpeed = 20f;
   // [SerializeField] private float acceleration = .5f;
    public static float currentSpeed;
    private float velocidadPreColision;
    public static bool Destruction;
    Rigidbody rb;
    public GoatController(ChangeAnimal changeAnimal, GameObject mesh, float movSpeed) : base(changeAnimal, mesh, movSpeed)
    {
    }

    public override void OnFixedUpdate()
    {
    }

    public override void OnStart()
    {
        if (_changeAnimal != null)
        {
            rb = _changeAnimal.GetComponent<Rigidbody>();
            if (rb == null)
            {
                Debug.LogError("Rigidbody no encontrado en el objeto _changeAnimal.");
            }
        }
        else
        {
            Debug.LogError("_changeAnimal no está asignado.");
        }
    }

    public override void OnChange()
    {
        base.OnChange();
        rb = _changeAnimal.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No se encontró un Rigidbody en el objeto _changeAnimal");
        }
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
        int batLayer = LayerMask.NameToLayer("BatActive");
        if (other.gameObject.layer == batLayer)
        {
            ChangeAnimal.batTrue = true;
            ChangeAnimal.batInto = true;
        }
    }

    public override void OnUpdate()
    {
        if (rb != null)
        {
            velocidadPreColision = Mathf.Abs(rb.velocity.z);
        }
        else
        {
            Debug.LogError("Rigidbody no inicializado en GoatController");
        }
        if (PlayerMovement.currentSpeed > _velocityForDestruction && Input.GetButton("Horizontal"))
        {
            Destruction = true;
        }
        else Destruction = false;
    }

    public override void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colisionó con: " + collision.gameObject.name);
        Debug.Log("Velocidad previa del toro en Z: " + velocidadPreColision);

        WallBull wall = collision.gameObject.GetComponent<WallBull>();

        if (wall != null)
        {
            if (velocidadPreColision > _velocityForDestruction)
            {
                _changeAnimal.DestroyObject(collision.gameObject);
                Debug.Log("AHHHH choque xd");
            }
            Debug.Log("choquis");
        }
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