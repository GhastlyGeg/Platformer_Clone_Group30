using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

// what
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
    }
}
