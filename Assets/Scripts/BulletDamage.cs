using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public float damage;
    public float LifeTime;
    [SerializeField] PlayerLife healtCode;
    private void Start()
    {
        Destroy(gameObject, LifeTime);

        GameObject player = GameObject.Find("Player");

        if (player != null)
        {
            healtCode = player.GetComponent<PlayerLife>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (healtCode != null)
        {
            healtCode.TakeDamage(damage);
        }
    }
}