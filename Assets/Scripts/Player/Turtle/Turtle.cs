using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    public float parryWindow = 0.5f;
    [SerializeField] private float speed = 0.5f;
    private bool isParrying = false;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(Parry());
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float dir = Input.GetAxis("Horizontal");

        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, dir * speed);
    }


    IEnumerator Parry()
    {
        isParrying = true;
        yield return new WaitForSeconds(parryWindow);
        isParrying = false;
    }


    private void OnTriggerEnter(Collider collision)
    {
        BullEnemy bull = collision.gameObject.GetComponent<BullEnemy>();

        if (isParrying && bull != null)
        {
            ReflectProjectile(bull);
        }
    }

    void ReflectProjectile(BullEnemy bull)
    {
        Rigidbody rb = bull.GetComponent<Rigidbody>();

        if (rb != null && !Input.GetButton("Horizontal"))
        {
            //rb.velocity = -rb.velocity;

            rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, rb.velocity.z);

            bull.isReflected = true;

        }
        
        if (rb != null && Input.GetButton("Horizontal"))
        {
            rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, rb.velocity.z + 2);
            //rb.velocity = -rb.velocity;

            bull.isReflected = true;

        }
    }
}
