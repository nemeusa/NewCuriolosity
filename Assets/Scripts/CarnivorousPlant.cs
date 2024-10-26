using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivorousPlant : MonoBehaviour
{
    [SerializeField] PlayerMovement playerCode;
    [SerializeField] Animator plantAni;
    private float attackTime;
    [SerializeField] float attackCooldown;

    private void Update()
    {
        ///attackTime += Time.deltaTime;

        if (playerCode.plantZone)
        {
            if (Time.time - attackTime < attackCooldown)
            {
                return;

            }
            plantAni.Play("Attack");
            //Debug.Log("is attack");
            attackTime = Time.time;
        }
        else
        { 
            plantAni.Play("Idle");
            //Debug.Log("is chill");
        }
    }



}
