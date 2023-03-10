using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
        // load next scene
        Time.timeScale = 1;
        SceneManager.LoadScene("Level");
    }

    public void QuitGame() {
        // quit game
        Debug.Log("QUIT");
        Application.Quit();
    }
}
