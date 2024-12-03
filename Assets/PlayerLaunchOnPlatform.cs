using System.Collections;
using UnityEngine;

public class PlayerLaunchOnPlatform : MonoBehaviour
{
    public float tiempoDeEspera = 2f; // Tiempo que el jugador debe estar parado en la plataforma (modificable desde el Inspector)
    public float fuerzaDeLanzamiento = 10f; // Fuerza con la que el jugador será lanzado hacia arriba (modificable desde el Inspector)
    public LayerMask capaPlataforma; // Capa de la plataforma (modificable desde el Inspector)

    private bool estaEnPlataforma = false;
    private float tiempoEstacionario = 0f;
    private Rigidbody rb;

    void Start()
    {
        // Obtener el componente Rigidbody del jugador para aplicar la fuerza
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (estaEnPlataforma)
        {
            // Acumulamos el tiempo que el jugador lleva parado en la plataforma
            tiempoEstacionario += Time.deltaTime;

            // Si el jugador ha estado el tiempo suficiente sobre la plataforma, lanzarlo
            if (tiempoEstacionario >= tiempoDeEspera)
            {
                LanzarJugador();
            }
        }
        else
        {
            // Si el jugador sale de la plataforma, resetear el contador de tiempo
            tiempoEstacionario = 0f;
        }
    }

    // Método que se llama cuando el jugador es lanzado
    void LanzarJugador()
    {
        // Aplicamos una fuerza hacia arriba
        rb.AddForce(Vector3.up * fuerzaDeLanzamiento, ForceMode.Impulse);
        tiempoEstacionario = 0f; // Reiniciar el contador de tiempo después de lanzar al jugador
    }

    // Detectar cuando el jugador entra en contacto con la plataforma
    void OnCollisionEnter(Collision collision)
    {
        // Verificamos si el objeto con el que colisionamos pertenece a la capa de la plataforma
        if (((1 << collision.gameObject.layer) & capaPlataforma) != 0)
        {
            estaEnPlataforma = true;
        }
    }

    // Detectar cuando el jugador sale de la plataforma
    void OnCollisionExit(Collision collision)
    {
        // Verificamos si el objeto con el que salimos pertenece a la capa de la plataforma
        if (((1 << collision.gameObject.layer) & capaPlataforma) != 0)
        {
            estaEnPlataforma = false;
        }
    }
}