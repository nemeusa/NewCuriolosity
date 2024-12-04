using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletEnemy : MonoBehaviour
{
    public float damage;
    [SerializeField] float speed;
    public bool isReflected;
    public static bool noPuedeParriar;
    [SerializeField] float destroyTime = 2.5f;
    [SerializeField] float parryTime = 2;
    public static bool interruptor;

    private void Start()
    {
        StartCoroutine(DestroyBullet(destroyTime));
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = -transform.up * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerLife healtCode = other.gameObject.GetComponentInParent<PlayerLife>();

        if (healtCode != null && !TurtleController.isParrying)
        {
            Debug.Log("auch");
            healtCode.TakeDamage(damage);
            Destroy(gameObject);
        }

        EnemyLife enemy = other.gameObject.GetComponent<EnemyLife>();

        if (enemy != null && isReflected)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Debug.Log("anda crack");
        }
        else if (enemy == null && TurtleController.isParrying) Debug.Log("no anda pa´");

        int interruptorLayer = LayerMask.NameToLayer("Interruptor");

        if (other.gameObject.layer == interruptorLayer) interruptor = true;
    }

    public void Reflect()
    {
        if (!noPuedeParriar)
        {
            StopAllCoroutines();
            StartCoroutine(DestroyBullet(parryTime));
            Renderer objRenderer = GetComponent<Renderer>();
            objRenderer.material.color = Color.green;
            isReflected = true;
        }
    }

    IEnumerator DestroyBullet(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
