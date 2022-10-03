using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_mainMenu : MonoBehaviour
{
public void PlayGame()
{
SceneManagement.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
}

public void QuitGame()
{
    Application.Quit();
} 
}