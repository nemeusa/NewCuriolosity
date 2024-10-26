using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingPlatform : MonoBehaviour

{
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }
    // private void Start()
    //{
    //  GetComponent<Rigidbody>().useGravity =false;
    //}
    private void OnTriggerEnter(Collider collider)
    {
        rb.useGravity = true;
    }
}