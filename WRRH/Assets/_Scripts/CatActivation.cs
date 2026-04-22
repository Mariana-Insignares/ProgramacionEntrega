using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatActivation : MonoBehaviour
{
    public GameObject catNextZone; // El gato que aparece 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // El gato actual desaparece
            if (catNextZone != null) catNextZone.SetActive(true);

            Destroy(gameObject); // El gato "sale de escena"
        }
    }
}
