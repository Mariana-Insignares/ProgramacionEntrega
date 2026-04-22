using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    // Esto crea un menú desplegable en el Inspector de Unity
    public enum ItemType { Llave, Vida, Flor }
    public ItemType tipo;

    [Header("Ajustes")]
    public int puntosPorFlor = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Solo funciona si el objeto que lo toca tiene el Tag "Player"
        if (collision.CompareTag("Player"))
        {
            // Ejecuta una acción distinta según el tipo que elijas en el Inspector
            switch (tipo)
            {
                case ItemType.Llave:
                    PlayerStats.hasKey = true;
                    Debug.Log("Llave recogida");
                    break;

                case ItemType.Flor:
                    PlayerStats.score += puntosPorFlor;
                    Debug.Log("Puntos: " + PlayerStats.score);
                    break;

                case ItemType.Vida:
                    PlayerStats.health++;
                    Debug.Log("Vida extra. Salud: " + PlayerStats.health);
                    break;
            }

            // El objeto desaparece de la escena después de ser recogido
            Destroy(gameObject);
        }
    }
}