using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    public Transform player; // Asigna el jugador desde el Inspector
    public GameObject balaPrefab; // Prefab de la bala
    public Transform puntoDisparo; // Lugar desde donde disparar
    public float tiempoEntreDisparos = 2f; // Tiempo entre cada disparo
    public float velocidadBala = 20f; // Velocidad de la bala
    public float velocidadRotacion = 5f; // Velocidad de rotación de la torreta
    [SerializeField] private float follow = 13;

    private float tiempoSiguienteDisparo;

    void Update()
    {
        // Apuntar hacia el jugador
        Vector3 direccion = player.position - transform.position;
        direccion.x = 0; // Ignorar la altura para mantener la torreta horizontal
        Quaternion rotacionObjetivo = Quaternion.LookRotation(direccion);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo, velocidadRotacion * Time.deltaTime);

        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer <= follow)
        {
            // Disparar
            if (Time.time >= tiempoSiguienteDisparo)
            {
                Disparar(direccion.normalized);
                tiempoSiguienteDisparo = Time.time + tiempoEntreDisparos;
            }
        }
    }

    void Disparar(Vector3 direccion)
    {
        GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, Quaternion.identity);
        Rigidbody rb = bala.GetComponent<Rigidbody>();
        rb.velocity = direccion * velocidadBala;
    }
}
