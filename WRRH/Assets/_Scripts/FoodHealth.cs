using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodHealth : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Accede a playerHealth
            PlayerHealth healthScript = collision.GetComponent<PlayerHealth>();

            // Suponiendo que queremos curar 1 punto de vida
            // Nota: Podrias necesitar hacer currentHealth publico en PlayerHealth
            // o crear un metodo Heal() alli siguiendo tu estructura.
            Destroy(gameObject);
        }
    }
}