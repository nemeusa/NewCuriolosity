using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAttack : MonoBehaviour
{
    public float damage;
    [SerializeField] PlayerLife healtCode;

    private void OnTriggerEnter(Collider other)
    {
            healtCode.TakeDamage(damage);
    }


}
