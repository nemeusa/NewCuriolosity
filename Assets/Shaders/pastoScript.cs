using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pastoScript : MonoBehaviour
{
    public GameObject player;
    private Material grassMat;

   
    void Start()
    {
        grassMat= GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;
        //print(playerPos);
        grassMat.SetVector("_PlayerPos", playerPos);
        grassMat.SetFloat("_Range", 2f);
    }
}
