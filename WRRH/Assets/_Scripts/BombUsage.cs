using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombSystem : MonoBehaviour
{
    public int bombCount = 0;
    public GameObject bombPrefab;
    public Text bombText; // Arrastrar el texto del HUD 

    void Update()
    {
        UpdateHUD();
        UseBomb();
    }

    void UpdateHUD()
    {
        if (bombText != null)
        {
            bombText.text = "Bombas: " + bombCount;
        }
    }

    void UseBomb()
    {
        // Se usa la tecla B para soltar bomba si tiene existencias
        if (Input.GetKeyDown(KeyCode.B) && bombCount > 0)
        {
            Instantiate(bombPrefab, transform.position, Quaternion.identity);
            bombCount--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Recoger bomba
        if (collision.CompareTag("BombItem"))
        {
            bombCount++;
            Destroy(collision.gameObject);
        }
    }
}