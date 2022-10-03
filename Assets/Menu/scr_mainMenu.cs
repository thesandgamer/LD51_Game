using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_mainMenu : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<scr_audioManager>().Play("MainMenu");

    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        FindObjectOfType<scr_audioManager>().Stop("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    } 
}