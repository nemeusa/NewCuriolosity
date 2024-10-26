using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TransManager : MonoBehaviour
{
    public CinemachineVirtualCamera _currentCamera;
    public void Start()
    {
        _currentCamera.Priority++;
    }

    public void UpdateCamera(CinemachineVirtualCamera target)
    {
        _currentCamera.Priority--;
        _currentCamera = target;
        _currentCamera.Priority = _currentCamera.Priority + 2;
    }
}
