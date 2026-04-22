using UnityEngine;

public class Bomb : MonoBehaviour
{
    [Header("Ajustes de Explosión")]
    public float delay = 2f;          // Tiempo antes de la detonación
    public GameObject explosionEffect; // Efecto visual

    [Header("Detección de Zona")]
    public LayerMask validZoneLayer;  // Capa de la zona permitida (ej: "BombZone")
    public float detectionRadius = 1f;

    private float _countdown;
    private bool _hasExploded = false;

    void Start()
    {
        _countdown = delay;

        // Al aparecer, verificamos si estamos en una zona válida
        if (!IsInValidZone())
        {
            Debug.Log("Intento de uso fuera de zona. Bomba cancelada.");
            // Si no está en zona, se destruye inmediatamente sin explotar
            // Nota: El script que la crea (BombSystem/BombUsage) debe validar esto
            // para no restar la bomba del inventario de PlayerStats.
            Destroy(gameObject);
        }
    }

    void Update()
    {
        _countdown -= Time.deltaTime;

        // Efecto visual de advertencia antes de estallar
        if (_countdown <= 0.8f)
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (sr != null) sr.color = Color.red;
        }

        if (_countdown <= 0f && !_hasExploded)
        {
            Explode();
        }
    }

    public bool IsInValidZone()
    {
        // Verifica físicamente si hay un colisionador de la zona designada
        Collider2D zone = Physics2D.OverlapCircle(transform.position, detectionRadius, validZoneLayer);
        return zone != null;
    }

    void Explode()
    {
        _hasExploded = true;

        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        // Aquí se puede añadir lógica para destruir objetos con Tags específicos como "Breakable"
        Debug.Log("¡Bomba detonada con éxito!");

        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}