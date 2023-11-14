 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Harms, Greg & Brown, Dylan
//11/13/2023
//Handles Menu Options
public class GameOVer : MonoBehaviour
{
    public void RetryGame()
    {
        // SNAP BACK TO REALITY
        SceneManager.LoadScene(1); 
    }

    public void QuitGame()
    {
        //the game kills itself (in game)
        Application.Quit();

        Debug.Log("Quits the Game");
    }
}
