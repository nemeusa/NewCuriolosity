using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet2 : MonoBehaviour
{
    [SerializeField] float speed;


    private void Start()
    {
        Destroy(gameObject, 2);
    }
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyLife enemy = other.gameObject.GetComponent<EnemyLife>();

        if (enemy != null) Destroy(other.gameObject);

        Destroy(gameObject);
    }
}
