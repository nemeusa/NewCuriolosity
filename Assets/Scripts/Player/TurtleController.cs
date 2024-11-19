using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleController : CreatureController
{
    public float parryWindow = 1f;
    public static bool isParrying = false;
    [SerializeField] private GameObject turtle;
    
    [SerializeField] float raycastMaxDistance = 2f;
    [SerializeField] LayerMask raycastMask;
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
        if (Input.GetButtonDown("Fire1") && !isParrying)
        {
            _changeAnimal.StartCoroutine(Parry());
            color();
        }
    }

    IEnumerator Parry()
    {
        isParrying = true;
        yield return new WaitForSeconds(parryWindow);
        isParrying = false;
    }

    public override bool CanChange()
    {
        return !Physics.Raycast(_mesh.transform.position, _mesh.transform.up, raycastMaxDistance, _changeAnimal.layerMask);
    }
    void ReflectProjectile(BulletEnemy bullet)
    {
        float Dir = Input.GetAxis("Horizontal");

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        Debug.Log("entre a reflect");
        if (rb != null && !Input.GetButton("Horizontal"))
        {
            rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, rb.velocity.z);

            bullet.Reflect();

        }

        if (rb != null && Input.GetButton("Horizontal"))
        {
            if (Dir > 0) rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, rb.velocity.z + 2);
            else if (Dir < 0) rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, rb.velocity.z - 2);

            bullet.Reflect();

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

    public override void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            PlayerMovement.takeWall = true;
        }

        else PlayerMovement.takeWall = false;
    }

    void color()
    {
        Renderer objRenderer = turtle.GetComponent<Renderer>();
        objRenderer.material.color = Color.green;
    }
}