using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //požene game
        SceneManager.LoadScene("SampleScene");
    }

    public void Back()
    {

        SceneManager.LoadScene("MainMenu");

    }


    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Quitgame()
    {
        Application.Quit();
    }
}
