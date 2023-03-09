using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void PlayGame() {
        // load next scene
        Time.timeScale = 1;
        SceneManager.LoadScene("Level");
    }

    public void QuitToMenu() {
        // quit game
        SceneManager.LoadScene("Menu");
    }
}
