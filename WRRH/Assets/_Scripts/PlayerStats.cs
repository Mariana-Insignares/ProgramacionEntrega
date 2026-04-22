using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    //  Puntos
    public static int score = 0;

    //  Salud
    public static int health = 3;

    // "Inventario"
    public static bool hasKey = false;
    public static bool hasBomb = false;

    // Reinicio cuando haya gameover

    public static void Reset()
    {
        score = 0;
        health = 3;
        hasKey = false;
        hasBomb = false;
        Debug.Log("Estadísticas reiniciadas");
    }
}