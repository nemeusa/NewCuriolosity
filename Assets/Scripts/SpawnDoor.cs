using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDoor : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] float fireRate = 1f;
    [SerializeField] float breakRate = 1f;
    private float nextFireTime = 0f;
    private float breakTime = 0f;

    private void Update()
    {
            if (Time.time >= nextFireTime && breakTime < breakRate)
            {
                Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                nextFireTime = Time.time + 1f / fireRate;
                breakTime += Time.deltaTime;
                
            }
            else if (breakTime > breakRate)
            {
                    breakTime = 0;
            }
        
    }

    public void IsDead()
    {
        Destroy(gameObject);
    }
}
