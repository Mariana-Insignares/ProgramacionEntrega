using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestLogic : MonoBehaviour
{
    public Sprite chestOpenedSprite;
    private SpriteRenderer _spriteRenderer;
    private bool _isOpened = false;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Se activa solo si el jugador tiene la llave
        if (collision.CompareTag("Player") && PlayerStats.hasKey && !_isOpened)
        {
            _isOpened = true;
            PlayerStats.hasKey = false; // Desaparece la llave del HUD
            PlayerStats.hasBomb = true; // bombas al hud

            // Cambiar imagen del cofre
            if (chestOpenedSprite != null) _spriteRenderer.sprite = chestOpenedSprite;

            Debug.Log("Cofre abierto: Llave usada, Bombas recibidas");
        }
    }
}