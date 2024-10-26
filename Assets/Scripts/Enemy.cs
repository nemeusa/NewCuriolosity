using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speedDefaul;
    [SerializeField] public float currentSpeed;

    private void Start()
    {
        currentSpeed = speedDefaul;
    }
    void Update()
    {
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
    }

    public void Slow (float amount, float duration) 
    {
        currentSpeed = speedDefaul * amount;

        Invoke(nameof(ResetSpeed), duration);
    }

    private void ResetSpeed(){ currentSpeed = speedDefaul; }
}
