using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTorreta : MonoBehaviour
{
    [SerializeField] private float tiempoVida = 5f;
    [SerializeField] private float damage;

    void Start()
    {
        Destroy(gameObject, tiempoVida); // Destruir la bala despu�s de cierto tiempo
    }

    void OnCollisionEnter(Collision collision)
    {
        // Aqu� puedes manejar la l�gica de colisi�n (como da�ar al jugador o destruir la bala).
        Destroy(gameObject); // Destruir la bala al impactar
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerLife healtCode = other.gameObject.GetComponentInParent<PlayerLife>();

        if (healtCode != null && !TurtleController.isParrying)
        {
            Debug.Log("auch");
            healtCode.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
