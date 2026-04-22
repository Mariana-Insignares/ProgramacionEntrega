using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Rigidbody2D _rb;

    [Header("Configuración de Salto")]
    public float bounceForce = 10f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (_rb.velocity.y < 0)
            {
                EnemyHealth enemy = collision.GetComponent<EnemyHealth>();

                if (enemy != null)
                {
                    _rb.velocity = new Vector2(_rb.velocity.x, 0f);
                    _rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);

                    enemy.Die();
                }
                else
                {
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}
