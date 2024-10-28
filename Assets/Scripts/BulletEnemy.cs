using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletEnemy : MonoBehaviour
{
    public float damage;
    [SerializeField] float speed;
    public bool isReflected;

    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = -transform.up * speed;
    }

    void Update()
    {
        if (isReflected) color();
        Destroy(gameObject, 2.5f);
        //transform.Translate(Vector3.down * speed * Time.deltaTime);   
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerLife healtCode = other.gameObject.GetComponentInParent<PlayerLife>();

        if (healtCode != null && !isReflected && !TurtleController.isParrying)
        {
            Debug.Log("auch");
            healtCode.TakeDamage(damage);
            Destroy(gameObject);
        }

        EnemyLife enemy = other.gameObject.GetComponent<EnemyLife>();

        if (enemy != null && isReflected)
        {
            Destroy(other.gameObject);
            Debug.Log("FUNCAAA");
        } 
    }


    void color()
    {
        Renderer objRenderer = GetComponent<Renderer>();
        objRenderer.material.color = Color.green;
    }
}
