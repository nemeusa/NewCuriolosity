using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{
    void Update()
    {
      
    }

    private void OnDrawGizmos()
    {
        // Origen del BoxCast
        Vector3 origin = transform.position;

        // Dirección y distancia del BoxCast
        Vector3 direction = transform.up;
        float distance = 1.3f;

        // Tamaño del BoxCast (ajústalo según tu implementación)
        Vector3 boxSize = new Vector3(0.5f, 0.1f, 0.56f);

        // Posición final (donde termina el BoxCast)
        Vector3 endPosition = origin + direction * distance;

        // Dibujar la posición inicial
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(origin, boxSize);

        // Dibujar la posición final
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(endPosition, boxSize);

        // Dibujar una línea entre las posiciones
        Debug.DrawLine(origin, endPosition, Color.blue);
        
    }
}
