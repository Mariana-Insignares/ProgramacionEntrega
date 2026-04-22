using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // iniciar o reiniciar el juego
    public void StartGame()
    {
        SceneManager.LoadScene("Level");
    }

    // Pantalla win
    public void WinGame()
    {
        Debug.Log("You arrived to granny's house");
        // panel de UI win
    }

    // exit
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Goodbye!");
    }

    // GameOver desde PlayerHealth cuando currentHealth sea 0
    public void GameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}