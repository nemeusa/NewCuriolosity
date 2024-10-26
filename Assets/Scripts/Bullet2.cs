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
        SpawnDoor spawnCode2 = other.GetComponent<SpawnDoor>();
        Enemy2 enemyCode2 = other.GetComponent<Enemy2>();

        if (enemyCode2 != null) Destroy(other.gameObject);

        if (spawnCode2 != null)
        {
            Destroy(other.gameObject);
            Debug.Log("MUERTo xd");
        }

        Destroy(gameObject);
        Debug.Log("choque xd");
    }
}
