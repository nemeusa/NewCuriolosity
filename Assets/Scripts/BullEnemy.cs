using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullEnemy : MonoBehaviour
{
    public float speed = 10f;
    public bool isReflected;

    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = -transform.up * speed;
    }

   /* 
    private void OnTriggerEnter(Collider other)
    {
        Turtle turtle = other.gameObject.GetComponent<Turtle>();
        if (turtle != null && !isReflected)
        {
            // Lógica para dañar al jugador
        }

        EnemyLife enemy = other.gameObject.GetComponent<EnemyLife>();

        if (enemy != null && isReflected)
        {
            // Lógica para dañar al enemigo
        }
    }*/
}
