using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleController : CreatureController
{
    public float parryWindow = 1f;
    public static bool isParrying = false;
    [SerializeField] private GameObject turtle;
    public TurtleController(ChangeAnimal changeAnimal, GameObject mesh, float movSpeed) : base(changeAnimal, mesh, movSpeed)
    {
        turtle = mesh;
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
        if (Input.GetKeyDown(KeyCode.W))
        {
            _changeAnimal.StartCoroutine(Parry());
            color();
        }
    }

    IEnumerator Parry()
    {
        //Debug.Log("parrying..");
        isParrying = true;
        yield return new WaitForSeconds(parryWindow);
        isParrying = false;
        //Debug.Log("parry end");
    }


    void ReflectProjectile(BulletEnemy bullet)
    {
        float Dir = Input.GetAxis("Horizontal");

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        Debug.Log("entre a reflect");
        if (rb != null && !Input.GetButton("Horizontal"))
        {
            rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, rb.velocity.z);

            bullet.isReflected = true;

        }

        if (rb != null && Input.GetButton("Horizontal"))
        {
            if (Dir > 0) rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, rb.velocity.z + 2);
            else if (Dir < 0) rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, rb.velocity.z - 2);

            //rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, rb.velocity.z + 2);
            bullet.isReflected = true;

        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        BulletEnemy bullet = other.gameObject.GetComponent<BulletEnemy>();

        if (bullet == null)
        {
            Debug.Log("no colision");
        }
        else
        {
            Debug.Log("colision");
        }

        if (isParrying && bullet != null)
        {
            ReflectProjectile(bullet);
        }
    }

    public override void OnCollisionEnter(Collision collision)
    {
    }

    void color()
    {
        Renderer objRenderer = turtle.GetComponent<Renderer>();
        objRenderer.material.color = Color.green;
    }
}