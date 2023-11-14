using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Harms, Greg & Brown, Dylan
//11/13/2023
//Displays the coin and lives count in the UI space
public class UIManager : MonoBehaviour
{
    public NewBehaviourScript playerController;
    public TMP_Text livesText;


    void Update()
    {
        livesText.text = "Lives: " + playerController.lives;
    }
}
