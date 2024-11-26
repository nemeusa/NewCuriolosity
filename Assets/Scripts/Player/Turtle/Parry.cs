using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform spawnBullet;
    [SerializeField] PlayerLife playerLife;
    [SerializeField] BulletEnemy enemyCode;
    private void Update()
    {
        GameObject bullet = GameObject.Find("Bullet Enemy"); ;
        if (playerLife.IsParry)
        {
            Instantiate(Bullet, spawnBullet.position, spawnBullet.rotation);
        }
    }
}
