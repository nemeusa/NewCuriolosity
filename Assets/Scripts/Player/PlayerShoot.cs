using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private UnityEngine.Camera MainCamera;

    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject Bullet2;
    [SerializeField] Transform spawnBullet;
    [SerializeField] Transform spawnBullet2;
    [SerializeField] private ChangeAnimal changeCode;
    [SerializeField] float fireRate;
    public bool canShoot1;
    private float nextFireTime = 0f;

    [SerializeField] private PlayerAudio _playerAudio;
    void Awake()
    {
        if (MainCamera == null)
        {
            MainCamera = GameObject.FindWithTag("MainCamera").GetComponent<UnityEngine.Camera>();
        }
    }
    void Update()
    {
        //if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        //{
        //    Shoot(transform, gameObject);
        //    nextFireTime = Time.time + 1f / fireRate;
        //}
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime && canShoot1)
        {

            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }

        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime && !canShoot1)
        {

            Debug.Log("Disparo");
            Shoot2();
            nextFireTime = Time.time + 1f / fireRate;
        }

    }
    //void Shoot(Transform spawnPoint, GameObject bulletPrefab)
    //{

    //    Vector3 cursorPos = MainCamera.ScreenToWorldPoint(Input.mousePosition);

    //    cursorPos.z = spawnBullet.position.z; 

    //    Vector3 direction = (cursorPos - spawnBullet.position).normalized;

    //    GameObject bullet = Instantiate(Bullet, spawnBullet.position, Quaternion.identity);

    //    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //    bullet.transform.rotation = Quaternion.Euler(0, 0, angle);

    //    Rigidbody rb = bullet.GetComponent<Rigidbody>();
    //    if (rb != null)
    //    {
    //        rb.velocity = direction * 10f;
    //    }

    //    _playerAudio.PlayShootClip();
    //}
    public void FlashlightAim()
    {
        Vector3 cursorPos = MainCamera.GetComponent<UnityEngine.Camera>().ScreenToWorldPoint(Input.mousePosition);
        Vector3 direccion = cursorPos - transform.position;
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
        angulo = -angulo;
        transform.rotation = Quaternion.Euler(angulo, 90, 0);

        spawnBullet2.transform.rotation = Quaternion.Euler(angulo, 90, 0);
    }
    void Shoot()
    {
        Instantiate(Bullet, spawnBullet.position, spawnBullet.rotation);
        _playerAudio.PlayShootClip();
    }

    void Shoot2()
    {
        Instantiate(Bullet2, spawnBullet2.position, spawnBullet2.rotation);
        _playerAudio.PlayShootClip();
    }
}


