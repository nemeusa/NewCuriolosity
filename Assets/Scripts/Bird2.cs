using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird2 : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float destroyTime = 3;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] float fireRate = 1f;
    private float nextFireTime = 0f;

    private void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        Destroy(gameObject, destroyTime);

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
