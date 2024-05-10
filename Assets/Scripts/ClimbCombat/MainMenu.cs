using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Load Scene
    public void Play()
    {
        SceneManager.LoadScene("7oooda");
    }

    // Quit Game
    public void Quit()
    {
        Application.Quit();
        Debug.Log("PLayer has left the game");
    }
}
