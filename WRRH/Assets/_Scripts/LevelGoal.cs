using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGoal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // call win on GameManager en la escena para avisar que gano
            FindObjectOfType<GameManager>().WinGame();
        }
    }
}