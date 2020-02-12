using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public static void QuitGame()
    {
        Debug.Log("Application quit");
        Application.Quit();
    }

    public static void OpenHighScore()
    {
        SceneManager.LoadScene(2);
    }
}
