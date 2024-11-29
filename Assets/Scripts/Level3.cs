using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {    
        SceneManager.LoadScene("Level3");
    }
}
