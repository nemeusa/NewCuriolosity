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
        Destroy(gameObject, 0.7f);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Enemy enemy = other.GetComponent<Enemy>();
        EnemyLife enemy = other.gameObject.GetComponent<EnemyLife>();
        WallBull wall = other.gameObject.GetComponent<WallBull>();

        collisionAnim.Play("Bullet1_Impact");

        if (enemy != null)
        {
            PlayImpactEnemClip();
            //enemy.Slow(slowAmount, slowDuration);
            Destroy(other.gameObject);
            Debug.Log("muerto pa");
        }

        if (wall != null)
        {
            PlayImpactEnemClip();
            Destroy(other.gameObject);
        }
            Destroy(gameObject, collisionAnim["Bullet1_Impact"].length);
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
