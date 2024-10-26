using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bull : MonoBehaviour
{
    [SerializeField] float VelocityForDestruction;
    [SerializeField] private float baseSpeed = 5f;
    [SerializeField] private float maxSpeed = 20f;
    [SerializeField] private float acceleration = 0.5f;

    private float currentSpeed;
    private Rigidbody rb;

    private float velocidadPreColision;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = baseSpeed;
    }

    private void Update()
    {
        //velocidadPreColision = Mathf.Abs(rb.velocity.z);
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float dir = Input.GetAxis("Horizontal");

        if (dir != 0)
        {
            currentSpeed += acceleration * Time.fixedDeltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, baseSpeed, maxSpeed);
        }
        else
        {
            currentSpeed = baseSpeed;
        }

        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, dir * currentSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colisionó con: " + collision.gameObject.name);
        Debug.Log("Velocidad previa del toro en Z: " + velocidadPreColision);

        WallBull wall = collision.gameObject.GetComponent<WallBull>();

        if (wall != null)
        {
            if (velocidadPreColision > VelocityForDestruction)
            {
                Destroy(collision.gameObject);
                Debug.Log("AHHHH choque xd");
            }
            Debug.Log("choquis");
        }
    }

}
