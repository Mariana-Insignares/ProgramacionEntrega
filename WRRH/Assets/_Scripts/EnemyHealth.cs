using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Enemy Death")]
    public int scoreValue = 50; // Puntos que da al morir
    public GameObject deathEffect; // Animacion muerte

    public void Die()
    {
        // Suma puntos a PlayerStats
        PlayerStats.score += scoreValue;

        Debug.Log("Enemigo derrotado. Puntos totales: " + PlayerStats.score);

        // animacion death
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    //muere porque cae 
    private void Update()
    {
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }
}