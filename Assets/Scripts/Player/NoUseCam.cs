using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class NoUseCam : MonoBehaviour
{
   // [SerializeField] private CinemachineVirtualCamera virtualCameraUp;
    [SerializeField] private CinemachineVirtualCamera virtualCameraDown;
   // [SerializeField] private KeyCode lookUp;
    [SerializeField] private KeyCode lookDown;

    private void Update()
    {
        if (Input.GetKeyDown(lookDown))
        {
            virtualCameraDown.Priority = 3;
        }
        else if (Input.GetKeyUp(lookDown))
        {
            virtualCameraDown.Priority = 0;
        }

      /*  if (Input.GetKeyDown(lookUp))
        {
            virtualCameraUp.Priority = 3;
        }
        else if (Input.GetKeyUp(lookUp))
        {
            virtualCameraUp.Priority = 0;
        }*/
    }
}
