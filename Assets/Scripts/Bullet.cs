using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float slowDuration;
    [SerializeField] float slowAmount;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);   
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.Slow(slowAmount, slowDuration);
        }
            Destroy(gameObject);
        Debug.Log("choque xd");
    }
}
