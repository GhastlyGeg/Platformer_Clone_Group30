using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Harms, Greg & Brown, Dylan
//11/13/2023
//Provides required aspects for opening the final door
public class FinalDoor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (GetComponent<NewBehaviourScript>().jumpPack == true && GetComponent<NewBehaviourScript>().heavyBullet == true)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            Debug.Log("Enemies remain! Find them");
        }
    }
}
