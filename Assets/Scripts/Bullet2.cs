using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet2 : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] private Animation collisionAnim;

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

        collisionAnim.Play("Bullet2_Impact");

        if (enemy != null) 
        {
            PlayImpactEnemClip();
            Destroy(other.gameObject);
        }

        Destroy(gameObject, collisionAnim["Bullet2_Impact"].length);
    }

    public void PlayImpactClip()
    {
        AudioManager.Instance.ImpactSource.Play();
    }

    public void PlayImpactEnemClip()
    {
        AudioManager.Instance.ImpactEnemSource.Play();
    }
}
