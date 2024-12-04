using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuerpoSpin : MonoBehaviour
{
    public Transform player;
    [SerializeField] float speed;
    [SerializeField] float follow = 12.5f;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer <= follow)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, direction.z * speed);
            Debug.Log(" te sigoooo");
        }
        else
        {
            Debug.Log("no te sigoooo :(");
            // Detener al enemigo si está fuera del rango
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
        }
    }
}