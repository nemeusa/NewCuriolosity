using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontGoat : MonoBehaviour
{
    bool detected1;
    bool detected2;
    public static bool dontGoat;
    [SerializeField] float raycastDistance;
    [SerializeField] Transform raycast1;
    [SerializeField] Transform raycast2;
    void Update()
    {
        detected1 = Physics.Raycast(raycast1.position, Vector3.up, raycastDistance);
        detected2 = Physics.Raycast(raycast2.position, Vector3.up, raycastDistance);

        if (detected1 || detected2) dontGoat = true;
        else dontGoat = false;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(raycast1.position, raycast1.position + Vector3.up * raycastDistance);
        Gizmos.DrawLine(raycast2.position, raycast2.position + Vector3.up * raycastDistance);
    }
}
