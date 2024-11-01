using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject Bullet2;
    [SerializeField] Transform spawnBullet;
    [SerializeField] Transform spawnBullet2;
    [SerializeField] float fireRate;
    private float nextFireTime = 0f;

    [SerializeField] private AudioManager _audioManager;

    void Update()
    {
        if (Input.GetButtonDown("Fire2") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
        
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            Shoot2();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        Instantiate(Bullet, spawnBullet.position, spawnBullet.rotation);
        _audioManager.BulletSource.Play();
    }
    
    void Shoot2()
    {
        Instantiate(Bullet2, spawnBullet2.position, spawnBullet2.rotation);
        _audioManager.BulletSource.Play();
    }
}
