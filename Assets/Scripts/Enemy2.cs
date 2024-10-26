using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [Header ("Move")]
    [SerializeField] float speed;
    [SerializeField] float leftLimit;
    [SerializeField] float rightLimit;

    [Header ("Shoot")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] float fireRate = 1f;
    private float nextFireTime = 0f;

    private bool movingRight = true;

    void Update()
    {
        if (movingRight)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        if (transform.position.z >= rightLimit)
        {
            movingRight = false;
        }
        else if (transform.position.z <= leftLimit)
        {
            movingRight = true;
        }
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }

    public void IsDead()
    {
        Destroy(gameObject);
    }
}
