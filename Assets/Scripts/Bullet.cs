using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float slowDuration;
    [SerializeField] float slowAmount;

    [SerializeField] private Animation collisionAnim;


    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);   
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();

        collisionAnim.Play("Bullet1_Impact");

        if (enemy != null)
        {
            PlayImpactEnemClip();
            enemy.Slow(slowAmount, slowDuration);
        }
        Destroy(gameObject, collisionAnim["Bullet1_Impact"].length);
        Debug.Log("choque xd");
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
