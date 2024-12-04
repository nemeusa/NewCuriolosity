using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallParry : MonoBehaviour
{
    private void Update()
    {
        if (BulletEnemy.interruptor)
        {
            transform.Translate(0, -0.5f * 0.1f, 0);
            Destroy(gameObject, 2);
        }

    }
}