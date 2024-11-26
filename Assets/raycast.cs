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

        // Direcci�n y distancia del BoxCast
        Vector3 direction = transform.up;
        float distance = 1.3f;

        // Tama�o del BoxCast (aj�stalo seg�n tu implementaci�n)
        Vector3 boxSize = new Vector3(0.5f, 0.1f, 0.56f);

        // Posici�n final (donde termina el BoxCast)
        Vector3 endPosition = origin + direction * distance;

        // Dibujar la posici�n inicial
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(origin, boxSize);

        // Dibujar la posici�n final
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(endPosition, boxSize);

        // Dibujar una l�nea entre las posiciones
        Debug.DrawLine(origin, endPosition, Color.blue);
        
    }
}
