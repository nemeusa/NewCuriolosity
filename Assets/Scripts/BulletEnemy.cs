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
        StartCoroutine(DestroyBullet(2.5f));
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = -transform.up * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerLife healthCode = other.gameObject.GetComponent<PlayerLife>();
        if (healthCode != null && !isReflected)
        {
            Debug.Log("auch");
            healthCode.TakeDamage(damage);
        }

        EnemyLife enemy = other.gameObject.GetComponent<EnemyLife>();

        if (enemy != null && isReflected)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    public void Reflect()
    {
        StopAllCoroutines();
        StartCoroutine(DestroyBullet(1));
        Renderer objRenderer = GetComponent<Renderer>();
        objRenderer.material.color = Color.green;
    }

    IEnumerator DestroyBullet(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
