using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform targetPoint; // Punto arriba fuera de la cueva cuando la caperusa sube
    public float speed = 3f;
    private bool _shouldMove = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Se activa cuando el jugador se para encima
        if (collision.gameObject.CompareTag("Player"))
        {
            _shouldMove = true;
        }
    }

    void Update()
    {
        if (_shouldMove && targetPoint != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

            // Se detiene al llegar al destino y no vuelve a bajar
            if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
            {
                _shouldMove = false;
            }
        }
    }
}