using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenenamed : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {    
        SceneManager.LoadScene("Level 1");
    }
}
